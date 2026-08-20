import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Observable, Subscription } from "rxjs";
import { IntervalObservable } from "rxjs/observable/IntervalObservable";
import 'rxjs/add/operator/takeWhile';

import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material';

import { CachingService } from '../../../lib/caching';
import { WinPatchService } from '../../win-patch.service';
import { TicketGeneratorConfiguration } from '../../models/ticket-generator-configuration';
import { ErrorDialog } from '../../../lib/error-dialog';
import { ProgressBarDialog } from '../../../lib/progress-bar-dialog';


@Component({
  selector: 'app-ticket-generator-preview',
  templateUrl: './ticket-generator-preview.component.html',
  styleUrls: ['./ticket-generator-preview.component.css']
})
export class TicketGeneratorPreviewComponent implements OnInit {

  accounts: number[];
  selectedAccountNumber: number;
  showPreviewResults: boolean;
  previews: string[];

  textareaRows: number;

  //patchingAccounts: PatchingAccount[];

  config: TicketGeneratorConfiguration;

  errorDialog: ErrorDialog;
  progressDialog: ProgressBarDialog;
  contentHeight: number;

  constructor(private router: Router, 
    private route: ActivatedRoute,
    private cache: CachingService,
    private patching: WinPatchService,
    private dlgError: MatDialog,
    private dlgProgress: MatDialog,) {

      this.errorDialog = new ErrorDialog(this.dlgError);
      this.progressDialog = new ProgressBarDialog(this.dlgProgress);
      this.cache.hideAccount();

}


  ngOnInit() {
    this.contentHeight = window.innerHeight - 320; 
    this.textareaRows = this.contentHeight/16;
    this.showPreviewResults = false; 

    //call service to get patching account numbers
    this.LoadPatchingAccounts()

  }

  ngOnDestroy(){
    
    // if (this.subProgress){
    //   this.subProgress.unsubscribe();
    // }
  }

  LoadPatchingAccounts(){
    this.accounts = new Array();
    this.progressDialog.open("Loading Accounts Numbers...", "indeterminate");
    this.patching.getPatchingAccountsOptedIn()
      .subscribe(a=> {
        var acct;
        var segments:string[];
        for( let url of a.resources){
          segments = url.split('/');
          acct = segments[segments.length-1];
          this.accounts.push(+acct)
        }
       this.progressDialog.close();
      },
      err => {
        this.errorDialog.showError("Ticket Generator", err, '', 'error');
      },
      () =>{
        this.progressDialog.close();
      }
    )
  }

  OnAccountSelect(e){
    this.selectedAccountNumber = e.value;
  }

  OnSubmit(){
    //call preview service(this.selectedAccountNumber)

    this.progressDialog.open("Generating Preview....", "indeterminate");

    this.patching.getTicketGeneratorPreview(this.selectedAccountNumber)
        // .finally(() => {
        //   this.progressBar.close();
        // })
        .subscribe(
          results =>{
                this.previews = results;
                this.showPreviewResults = true;
                this.progressDialog.close();
              },
              err => {
                this.errorDialog.showError("Ticket Generator", err, '', 'error');
              },
              () =>{
                this.progressDialog.close();
              }
            );
   
  }


  // GetProgress(){
  //   this.subProgress = IntervalObservable.create(100)
  //   .takeWhile(() => this.pctComplete <= 100 ) // only fires when component is alive
  //   .finally( () => {
  //     //this.CloseProgressBar();
  //     this.progressBar.close();
  //     this.showPreviewResults = true;
  //   })
  //   .subscribe(() => {
  //       this.pctComplete++;
  //       //this.UpdateProgress(this.pctComplete,"Device " + this.pctComplete);
  //       this.progressBar.updateProgress(this.pctComplete,"Device " + this.pctComplete);
  //     });
  // }
}


