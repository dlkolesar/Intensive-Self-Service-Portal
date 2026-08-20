import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Subscription } from "rxjs";
import { finalize } from 'rxjs/operators/finalize';
//import { IntervalObservable } from "rxjs/observable/IntervalObservable";
import 'rxjs/add/operator/takeWhile';

import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material';
import { CachingService } from '../../../lib/caching';
import { WinPatchService } from '../../win-patch.service';
import { CoreService, CoreProxyData } from '../../../lib/core/core.service';
import { TicketGeneratorConfiguration } from '../../models/ticket-generator-configuration';
import { PatchingTicketHistory } from '../../models/ticket-generator-history-data';
import { ErrorDialog } from '../../../lib/error-dialog';
import { ProgressBarDialog } from '../../../lib/progress-bar-dialog';


@Component({
  selector: 'app-ticket-generator-update',
  templateUrl: './ticket-generator-update.component.html',
  styleUrls: ['./ticket-generator-update.component.css']
})
export class TicketGeneratorUpdateComponent implements OnInit {
  selectedAccountNumber: number;
  showPreviewResults: boolean;
  totalItems: number;
  itemsCompleted: number;
  pctComplete: number = 0;
  subProgress: Subscription;

  coreToken: string;
  tickets: Array<PatchingTicketHistory>;
  runid: string;
  privateComment: boolean = false;
  ticketText: string = "";
  
  config: TicketGeneratorConfiguration;

  errorDialog: ErrorDialog;
  progressDialog: ProgressBarDialog;
  contentHeight: number;

  constructor(private router: Router, 
    private route: ActivatedRoute,
    private cache: CachingService,
    private patching: WinPatchService,
    private core: CoreService,
    private dlgError: MatDialog,
    private dlgProgress: MatDialog,) {

      this.errorDialog = new ErrorDialog(this.dlgError);
      this.progressDialog = new ProgressBarDialog(this.dlgProgress);
      this.cache.hideAccount();

}


  ngOnInit() {
    this.contentHeight = window.innerHeight - 320; 
    this.runid = this.GetCurrentRunID();
  }

  OnSubmit(){
    //get ticket generator config
    //login to core and get token
    //call service to get ticket numbers to update(based on switches)
    //foreach ticket
    //  set update flag = "N"
    //endFor

    //foreach ticket
    //  call CORE API(with token in header) to addComment
    //  set update flag = "Y"
    //endFor

    this.progressDialog.open("Mass Ticket Update", "indeterminate");
    this.progressDialog.updateProgress(0,"Getting Patching Ticket Configuration");
    
    this.patching.getTicketGeneratorConfig()
                    .subscribe(c=>{
                      this.config = c;
                      this.GetCoreToken();
                    },
                  err =>{
                    this.progressDialog.close();
                    this.errorDialog.showError("Ticket Generator", err, "Error reading Config", "error");
                    });
    

  }

  GetCoreToken(){
    this.progressDialog.updateProgress(0,"Getting CORE token");
    this.core.getCoreToken(this.config.coreURL, this.config.coreUser, this.config.corePwd)
          .subscribe(t=>{
            this.coreToken = t.authtoken;
            this.GetTicketsToUpdate();
            //this.GetTicketTest();
          },
          err =>{
            this.progressDialog.close();
            this.errorDialog.showError("Ticket Generator", err, "Error getting CORE token: ", "error")
          });
  }

  GetTicketTest(){
    var tkt = '';
    this.progressDialog.open("Mass Ticket Update", "indeterminate");
    this.progressDialog.updateProgress(0,"Getting ticket 200213-04135...");
    this.core.getTicket(this.config.coreURL, 
                        this.coreToken,
                        "200213-04135")
           .subscribe(tkt =>{
              console.log(tkt);
           },
           err =>{
             this.progressDialog.close();
             this.errorDialog.showError("Ticket Generator", err, "Error getting tickets", "error")
             }
           
        );//subscribe
  }

  GetTicketsToUpdate(){
    var tkt = '';
    this.progressDialog.open("Mass Ticket Update", "indeterminate");
    this.progressDialog.updateProgress(0,"Finding tickets to update");
    this.patching.getTicketGeneratorHistory(null,this.runid)
           .subscribe(apiColl =>{
              if (apiColl.count > 0){
                this.LoadTickets(apiColl.resources)
              }
              else{
                this.progressDialog.close();
                this.errorDialog.open("Ticket Generator", "No tickets found for runid=" + this.runid, "", "warning");
              }
           },
           err =>{
             this.progressDialog.close();
             this.errorDialog.showError("Ticket Generator", err, "Error finding tickets", "error")
             }
           
        );//subscribe
  }


  LoadTickets(ticketURLs){
    this.tickets = new Array<PatchingTicketHistory>();
    this.totalItems = ticketURLs.length;
    this.itemsCompleted = 0;
    this.pctComplete = 0;
    this.progressDialog.open("Mass Ticket Update", "determinate");
    this.progressDialog.updateProgress(0,"Finding tickets to update");
   

    for(var i=0;i<ticketURLs.length;i++){
        this.patching.getTicketGeneratorHistoryURL(ticketURLs[i])
        .pipe(finalize( () => {
                this.pctComplete = (++this.itemsCompleted/this.totalItems) * 100;
                this.progressDialog.updateProgress(this.pctComplete,"Finding tickets to update");
                if (this.pctComplete >= 100){
                  this.UpdateTickets();
                }
                
              })
            )
              .subscribe( pth=>{
                if ((!pth.updated) && (pth.account > 0)){
                  this.tickets.push(pth);
                }
              },
              err =>{
                this.progressDialog.close();
                this.errorDialog.showError("Ticket Generator",err, "Error finding tickets", "error")
                });
    }
  } 

  UpdateTickets(){
    this.totalItems = this.tickets.length;
    this.itemsCompleted = 0;
    this.pctComplete = 0;
   
    var segments;
    var tkt;

    if (this.totalItems == 0){
      this.progressDialog.close();
      this.errorDialog.open("Ticket Generator", "No tickets to update.  You may need to clear the 'updated' column of the PatchingTicketHistory table for this runid","", "warning");
    }
    else{
      for(var i=0;i<this.tickets.length;i++){
        this.core.addTicketComment(this.config.coreURL, 
                                  this.coreToken, 
                                  this.tickets[i].coreTicket, 
                                  this.ticketText, 
                                  this.privateComment)
            .pipe(finalize( () => {
                this.pctComplete = (++this.itemsCompleted/this.totalItems) * 100;
                this.progressDialog.updateProgress(this.pctComplete,"Adding comment to tickets");
                if (this.pctComplete >= 100){
                  this.UpdateTicketHistory();
                  //this.progressBar.close();
                }
              })
            )
              .subscribe(r=>{
                var idx = this.tickets.findIndex( (t, pos, arr) => 
                          t.coreTicket == r[0].load_arg
                        );
                this.tickets[idx].updated = true;
              },
              err =>{
                this.progressDialog.close();
                this.errorDialog.showError("Ticket Generator",err, "Error adding comment to ticket", "error")
                });
      }//for
    }//if/else
  }

  UpdateTicketHistory(){
    this.totalItems = this.tickets.length;
    this.itemsCompleted = 0;
    this.pctComplete = 0;
    for(var i=0;i<this.tickets.length;i++){
      if (!this.tickets[i].updated) {
        ++this.itemsCompleted;
        continue;
      }  //skip if update flag is not set

      this.patching.updateTicketGeneratorHistory(this.tickets[i].coreTicket, true)
      .pipe(finalize( () => {
              this.pctComplete = (++this.itemsCompleted/this.totalItems) * 100;
              this.progressDialog.updateProgress(this.pctComplete,"Updating Ticket Generator History");
              if (this.pctComplete >= 100){
                this.progressDialog.close();
              }
            })
          )
            .subscribe(()=>{
              
            },
            err =>{
              this.progressDialog.close();
              this.errorDialog.showError("Ticket Generator",err, "Error setting ticket history update flag", "error")
            });
    }//for
  }

  GetCurrentRunID(): string{
    var dt = new Date(Date.now());
    var yyyy = dt.getFullYear() * 100;
    var mm = (dt.getMonth() + 1);

    var runid = yyyy + mm;
    return runid.toString();

  }


  OnChangeType(e){
    //this.updateAllTickets = e.source.checked;

    // this.updateAutomaticTickets = false;
    // this.updateManualTickets = false;
    // this.updateAdvancedTickets = false;
  }



  // GetProgress(){
  //   this.subProgress = IntervalObservable.create(500)
  //   .takeWhile(() => this.pctComplete <= 100 ) // only fires when component is alive
  //   .subscribe(() => {
  //     this.pctComplete++;
  //     // this.patchingService.GetTicketGeneratorProgress().subscribe(pct => {
  //     //       this.pctComplete == pct;
  //     //     });
  //     });
  // }

}
