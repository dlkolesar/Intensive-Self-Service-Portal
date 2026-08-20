import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material';
import { Observable, Subscription } from "rxjs";
import { IntervalObservable } from "rxjs/observable/IntervalObservable";
import 'rxjs/add/operator/takeWhile';

import { CachingService } from '../../../lib/caching';
import { WinPatchService } from '../../win-patch.service';
import { ErrorDialog } from '../../../lib/error-dialog';



@Component({
  selector: 'app-ticket-generator-progress',
  templateUrl: './ticket-generator-progress.component.html',
  styleUrls: ['./ticket-generator-progress.component.css']
})
export class TicketGeneratorProgressComponent implements OnInit, OnDestroy{

  generatorIsRunning:boolean = false;
  pctComplete: number = 0;
  //subProgress: Subscription;
  //totalAccounts: number;
  //completedAccounts: number;
  


  errorDialog: ErrorDialog;
  contentHeight: number;

  constructor(private router: Router, 
              private route: ActivatedRoute,
              private cache: CachingService,
              private patching: WinPatchService,
              private dlgError: MatDialog) {

      this.errorDialog = new ErrorDialog(this.dlgError);
            this.cache.hideAccount();

}

  ngOnInit() {
    
  // //   this.subProgress = IntervalObservable.create(100)
  // //   .takeWhile(() => this.pctComplete < 100 ) // only fires when component is alive
  // //   .subscribe(() => {
  // //       this.pctComplete++;
  // //       // this.patchingService.GetTicketGeneratorProgress().subscribe(pct => {
  // //       //       this.pctComplete == pct;
  // //       //     });

  // //       if (this.pctComplete >= 100){
  // //         this.generatorIsRunning = false;      
  // //       }
  // //   });

  //   this.patching.getPatchingAccountsOptedIn()
  //         .subscribe(a=> {
  //             this.totalAccounts =  a.count;
  //             this.UpdateProgress();
  //         });
  this.UpdateProgress();
   }

  ngOnDestroy(){
    //this.subProgress.unsubscribe();
  }

  UpdateProgress(){
    //  this.subProgress = IntervalObservable.create(10000)
    //      .takeWhile(() => this.pctComplete < 100 )
    //      .subscribe(() => {
      var runid = this.GetCurrentRunID()
          this.patching.getTicketGeneratorProgress(runid)
              .subscribe( pct => {
                //this.completedAccounts = a;
                this.generatorIsRunning = true;

                //this.pctComplete = (this.completedAccounts/this.totalAccounts) * 100;
                this.pctComplete = +pct;
                if (this.pctComplete >= 100){
                  this.generatorIsRunning = false;      
                }
            },
          err => {
            if (err.status == 404){
              this.generatorIsRunning = false;
            }
            else{
              this.errorDialog.showError("Ticket Generator", err, '', 'error')
            }
          })
          //});
  }


  GetCurrentRunID(): string{
    var dt = new Date(Date.now());
    var yyyy = dt.getFullYear() * 100;
    var mm = (dt.getMonth() + 1);

    var runid = yyyy + mm;
    return runid.toString();

  }
}
