
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Subscription, from } from 'rxjs';
import { interval } from 'rxjs';
import { mergeMap, finalize } from 'rxjs/operators';
// import { mergeMap } from 'rxjs/operator/mergeMap';
// import { DataSource } from '@angular/cdk/collections';
// import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import {MatDialog, 
        MatTableDataSource, 
        MatSort
      } from '@angular/material';

import { AccountService, AccountData } from '../../../lib/account';
import { CachingService } from '../../../lib/caching';
import { AuthData } from '../../../lib/auth';

import { PatchingAccount } from '../../../windows-patching/models/patching-account';
import { PatchingClient } from '../../../windows-patching/models/patching-client';
import { WinPatchService } from '../../../windows-patching/win-patch.service';
import { ErrorDialog } from '../../../lib/error-dialog';
import { ProgressBarDialog } from '../../../lib/progress-bar-dialog';

import {ReportLine} from './report-line';


@Component({
  selector: 'app-missing-patches-report',
  templateUrl: './missing-patches-report.component.html',
  styleUrls: ['./missing-patches-report.component.css']
})

export class MissingPatchesReportComponent implements OnInit {

  
  account: AccountData;
  patchingAccount: PatchingAccount;
  servers: PatchingClient[];

  //newAccount:boolean; //indicates that the current account has never been opted in

  report: ReportLine[] = new Array();
  dsReport = new MatTableDataSource([]);

      
  columns: string[] = ['name', 'missingPatches' ];
  
  cfg: object;
  auth: AuthData;
  showForm: boolean = false;
  contentHeight: number;
  progressBarDialog: ProgressBarDialog;
  errorDialog: ErrorDialog
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;

  constructor( private router: Router, 
              private route: ActivatedRoute,
              private acctService: AccountService,
              private patching: WinPatchService,
              private cache: CachingService,
              private dlgError: MatDialog,
              private dlgProgress: MatDialog
          ) { 
    this.account = null;
    this.progressBarDialog = new ProgressBarDialog(this.dlgProgress);
    this.errorDialog = new ErrorDialog(this.dlgError);

    this.cache.showAccount(); //show the account in the banner

    //this.cfg = this.config.getConfig("winpatch");
    this.auth = this.cache.authData;
  }


  @ViewChild(MatSort, {static: false}) _sort: MatSort;
  //@ViewChild('filter') filter: ElementRef;

  ngOnInit() {
    console.log("win-patch.component: OnInit()");
    this.contentHeight = window.innerHeight - 72;  //toolbar height with margin


    this.account = this.cache.account;
    //this.servers = this.account.servers.filter(s => s.wsusid != null && s.wsusid != '00000000-0000-0000-0000-000000000000') as PatchingClient[];
    this.servers = this.account.servers as PatchingClient[];
    this.GetPatchingAccount();
  }

  ngAfterViewInit(){
    // this._sort.active = "name";

    // this.dsReport.sort = this._sort;
  }

  ngOnDestroy(){
  }

  GetPatchingAccount(){
    this.progressBarDialog.open("Loading Patching Account data", "indeterminate" );

    this.patching.getPatchingAccount(this.account.number)
      .subscribe( pa => {
        // this.progressBarDialog.close();
        this.patchingAccount = pa;

        if ((!this.patchingAccount.optedOut)&&(this.servers.length>0) ){
          this.GetPatchingClients();
        }
        else{
          this.progressBarDialog.close();

          this.errorDialog.open("Missing Patches Report", "Account is not opted in or the server list has not populated yet", "","warning");
        }

      },
      err => {
        console.log("apierror: " + err);
        this.progressBarDialog.close();

        if (err.status == 404){ //account not found in patchingAccounts table
          //show error -- not opted in
          this.errorDialog.open("Missing Patches Report", "Account is not opted in", "","warning");
        }
        else{
          this.errorDialog.showError("Patching Account", err,"","error");
        }
      });
  }

  GetPatchingClients(){
    this.progressBarDialog.open("Searching for Missing Patches", "determinate" );
    this.itemsComplete = 0;
    this.totalItems = this.servers.length;
    // this.servers.forEach( (svr, idx, arr) =>{
    //   this.GetPatchingClient(svr.deviceNumber);
    // });

    from(this.servers)
      .pipe(
        mergeMap(s => this.patching.getPatchingClient(s.deviceNumber), 100)
      )
      .subscribe( pc => {
        let index = this.servers.findIndex(d => d.deviceNumber === pc.deviceNumber);
        this.servers[index] = pc;
        
        this.servers[index].statusMessage = "";
        this.servers[index].statusIcon = ""; 
        this.servers[index].statusIconColor = "";

        if (pc.errors.length>0){
          this.servers[index].statusMessage = pc.errors.join('\r\n');
          this.servers[index].statusIcon = "warning"; 
          this.servers[index].statusIconColor = "orange";
        }

        if (pc.optedOut){
          this.servers[index].statusIcon = "cancel"; 
          this.servers[index].statusIconColor = "darkred";
          this.servers[index].statusMessage = "This server has been OPTED OUT ";
        }
        this.GetMissingPatches(index);
      },
      err => {
        console.log("apierror: " + err)
      });
  }

  // GetPatchingClient(num){
  //   this.patching.getPatchingClient(num)
  //   .subscribe( pc => {
  //       let index = this.servers.findIndex(d => d.deviceNumber === pc.deviceNumber);
  //       this.servers[index] = pc;
        
  //       this.servers[index].statusMessage = "";
  //       this.servers[index].statusIcon = ""; 
  //       this.servers[index].statusIconColor = "";

  //       if (pc.errors.length>0){
  //         this.servers[index].statusMessage = pc.errors.join('\r\n');
  //         this.servers[index].statusIcon = "warning"; 
  //         this.servers[index].statusIconColor = "orange";
  //       }

  //       if (pc.optedOut){
  //         this.servers[index].statusIcon = "cancel"; 
  //         this.servers[index].statusIconColor = "darkred";
  //         this.servers[index].statusMessage = "This server has been OPTED OUT ";
  //       }
  //       this.GetMissingPatches(index);
  //     },
  //     err => {
  //       console.log("apierror: " + err)
  //     },
  //     // () => {
  //     //   this.itemsComplete++;
  //     //   this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
  //     //   this.progressBarDialog.updateProgress(this.pctComplete,"");
  //     //   if (this.pctComplete >= 100) {
  //     //     this.showForm = true;
  //     //     this.progressBarDialog.close();
          
  //     //     //set initial sort order
  //     //     var sortedByName = this.report.sort( (a, b)  => {
  //     //         if (a.name == b.name){ return 0; }
  //     //         if (a.name < b.name) { return -1;}
  //     //         if (a.name > b.name) { return 1;}
  //     //       //return a.deviceNumber - b.deviceNumber;
  //     //     });

  //     //     this.dsReport = new MatTableDataSource(this.report);
          
  //     //     this.dsReport.sort = this._sort;
  //     //   }
  //     //}
  //   );
  // }

  GetMissingPatches(index: number){
    var svr = this.servers[index];

    this.patching.getMissingPatches(svr.deviceNumber)
    .pipe(finalize(
      () => { 
        //this.GetMissingPatchDetails();
        this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
        this.progressBarDialog.updateProgress(this.pctComplete,"");

        if (this.pctComplete >= 100){
          var rpt = this.report.filter(s => s.missingPatches.length > 0 || s.unSupportedOS);
                                
          
          this.dsReport = new MatTableDataSource(rpt);
          this._sort.active = "name";
          this._sort.direction = "asc";
          this.dsReport.sort = this._sort;
          
          this.showForm = true;
          this.progressBarDialog.close();
        }
      })
    )
      .subscribe(
          p => {
              if (p.length > 0){
                //var d = this.report.findIndex( u => u.targetId == p[0].targetId );
                var row = this.BuildReportRow(this.servers[index]);
                row.missingPatches = p;

                this.report.push(row);
              }
          },
          error => {
            if (error.status != 404){
              this.errorDialog.showError("Identify Missing Patches",
                             "error: " + error.status + ": " + error.statusMessage,
                             "",
                             "error"
                          );
              }
            },
          
        ); //subscribe

  }

  BuildReportRow(svr: PatchingClient): ReportLine{
    let row = new ReportLine();

    row.statusIcon = svr.statusIcon;
    row.statusIconColor = svr.statusIconColor;
    row.statusMessage = svr.statusMessage;
    row.deviceNumber = svr.deviceNumber;
    row.name = svr.name;
    
    row.targetId = svr.targetId;
    row.unSupportedOS = false;  // set based on os version numbers


    return row;
  }


  exportCSV(filename) {
    var csv = "Server, Patch Severity, Requires Reboot, Missing Patch, State\n"
    var col = "";
    var badOS = "This server is running an older OS version that is no longer supported by Microsoft and does not receive new security updates.";

    this.dsReport.data.forEach((record, j) => {
        if (record.missingPatches.length == 0){
          csv += '"' + record.name + '",,,' + badOS + ',\n';
        }
        else
        {
          for (let p of record.missingPatches)
          {
            csv += '"' +  record.name + '",';
            csv += '"' + p.severity + '",';
            csv += '"' + p.requiresReboot + '",';
            csv += '"' + p.title + '",';
            
            switch(p.state){
              case 3: csv += "Downloaded"; break;
              case 5: csv += "Failed"; break;
              case 6: csv += "Pending Reboot"; break;
            }
            csv += '\n';
          }
        }
    });

    this.DownloadFile(csv, filename);
  }


  DownloadFile(text, filename) {
    //console.log(text);
    var blob = new Blob([text], { type: 'text/csv;charset=utf-8;' });
    if (navigator.msSaveBlob) { // IE 10+
        navigator.msSaveBlob(blob, filename);
    }
    else //create a link and click it
    {
        var link = document.createElement("a");
        if (link.download !== undefined) // feature detection
        {
            // Browsers that support HTML5 download attribute
            var url = URL.createObjectURL(blob);
            link.setAttribute("href", url);
            link.setAttribute("download", filename);
            link.style.visibility = 'hidden';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
    }
  }
}