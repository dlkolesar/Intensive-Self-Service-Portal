import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { MatDialog, MatProgressSpinner } from '@angular/material';
import { from, forkJoin } from 'rxjs';
import { mergeMap } from 'rxjs/operators';
import { Chart} from 'chart.js';

import { AccountService, AccountData } from '../lib/account';
import { WinPatchService, PatchingAccount } from '../windows-patching';
import { CachingService } from '../lib/caching/caching.service';
import { ProgressBarDialog } from '../lib/progress-bar-dialog';
import { ErrorDialog } from '../lib/error-dialog';
import { ApiCollection } from '../lib/shared-data';

@Component({
  selector: 'ss-account-dashboard',
  templateUrl: './account-dashboard.component.html',
  styleUrls: ['./account-dashboard.component.css']
})
export class AccountDashboardComponent implements OnInit {

  account: AccountData;
  patchingAccount: PatchingAccount;

  pie1: Chart[];
  pie2: Chart[];

  patchingDash: {
    

  }

  progressBarDialog: ProgressBarDialog;
  errorDialog: ErrorDialog
  
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;

  constructor( private router: Router,
                private route: ActivatedRoute,
                private cache: CachingService,
                private dlgProgress: MatDialog,
                private dlgError: MatDialog,
                private winPatch: WinPatchService,
                private acct: AccountService) {
    
    this.progressBarDialog = new ProgressBarDialog(this.dlgProgress);
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.itemsComplete = 0;
    this.totalItems = 0;

    this.account = this.cache.account;
    
    this.cache.showAccount();
}


  ngOnInit() {
    this.pie1 = new Chart('pie1', {
      type: 'pie',
      data: {
        datasets: [{
          label: 'dataset label',
          data: [70,30],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)'],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            ],
          borderWidth: 1

        }],
    
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'OK',
            'Not OK'
        ]
      },
      options:{
        title: { display: true, text:"Pie Chart 1"},
        circumference: 2 * Math.PI, // use 1* PI to make a "gauge" or half pie
        responsive:true,
        maintainAspectRatio: false,
        legend: { display: false }
      }
    });

    this.pie2 = new Chart('pie2', {
      type: 'pie',
      data: {
        datasets: [{
          label: 'dataset label',
          data: [70,30],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)'],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            ],
          borderWidth: 1

        }],
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'OK',
            'Not OK'
        ]
      },
      options:{
        title: { display: true, text:"Pie Chart 2"},
        circumference: 2 * Math.PI, // use 1* PI to make a "gauge" or half pie
        responsive:true,
        maintainAspectRatio: false,
        legend: { display: false }
      }
    });
  }


  BuildClientList(acct){
    this.progressBarDialog.open("Account Dashboard", "determinate");
    this.progressBarDialog.updateProgress(0,"Summarizing Data....")
    this.winPatch.getPatchingClients(acct)
      .subscribe(
        a => { 
          this.GetPatchingClientData(a);
        },
        error => {this.router.navigate(['/']);},
        () => { }
      );
  }

  GetPatchingClientData(api){
    let errMsgs: string[];
    let errs: number = 0;
    let optedin: number = 0;
    let servers: number = 0;

    from(api.resources) //foreach url in the resources array
      .pipe(
        mergeMap( url => this.winPatch.getPatchingClientResource(url))  //execute GetObjectURL
      )
        .subscribe(
          s => { //patchingClient
            if (!s.optedOut){
              optedin++;
              
              if (s.errors.length > 0) { errs++; }
            }
          },
          error => {
            // this.ShowError("Loading Server Status Data",
            //         "error: " + error.status + ": " + error.statusMessage,
            //         "",
            //         "error");
          },
          () => { 
            servers++;
            this.pctComplete = Math.floor(((servers)/api.count)*100);
            //this.UpdateProgress(this.pct,"");

            if (this.pctComplete >= 100){
              //this.CloseProgressBar();
              //this.showDashboard = true;
              //this.pctIssues = Math.floor((errs/servers)*100);
              //this.issuesLabel = this.pctIssues + "%";

             // this.pctOptIn = Math.floor((optedin/servers)*100);
              //this.optinLabel = optedin + ' / ' + servers;
            }
          }
          
            
        );
  }
}
