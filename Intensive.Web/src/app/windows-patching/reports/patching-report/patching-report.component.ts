import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Subscription, from } from 'rxjs';
import { interval } from 'rxjs';
import { mergeMap, finalize, tap, map } from 'rxjs/operators';
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
import { ApiCollection } from 'src/app/lib/shared-data';
import { PatchStatus } from '../../models';


@Component({
  selector: 'app-patching-report',
  templateUrl: './patching-report.component.html',
  styleUrls: ['./patching-report.component.scss']
})
export class PatchingReportComponent implements OnInit {

  paramTo: string;
  paramFrom: string;
  paramIncludeStates: string;
  paramExcludeStates: string;
   
  account: AccountData;
  patchingAccount: PatchingAccount;
  servers: PatchingClient[];

  report: ReportLine[] = new Array();
  row: ReportLine;
  dsReport = new MatTableDataSource([]);
  title = "Patching Report";

  columns: string[] = ['name','patchingLevel', 'patches' ];
  
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
    this.showForm = false;
    this.pctComplete = 0;
  }


  @ViewChild(MatSort, {static: false}) _sort: MatSort;
  //@ViewChild('filter') filter: ElementRef;

  ngOnInit() {
    this.contentHeight = window.innerHeight - 72;  //toolbar height with margin
    this.account = this.cache.account;
    //this.servers = this.account.servers.filter(s => s.wsusid != null && s.wsusid != '00000000-0000-0000-0000-000000000000') as PatchingClient[];
    this.servers = this.account.servers as PatchingClient[];
    this.report = new Array<ReportLine>();

    //this.GetPatchingAccount();
  }

  ngAfterViewInit(){
    // this._sort.active = "name";

    // this.dsReport.sort = this._sort;
  }

  ngOnDestroy(){
  }

  GetPatchingAccount(){ //may not need this
    this.progressBarDialog.open("Loading Patching Account data", "indeterminate" );

    this.patching.getPatchingAccount(this.account.number)
      .subscribe( pa => {
        // this.progressBarDialog.close();
        this.patchingAccount = pa;

        //if ((this.patchingAccount.optedOut)||(this.servers.length == 0) ){
        if (this.servers.length == 0){
          this.progressBarDialog.close();
          this.errorDialog.open(this.title, "Account has no patching clients or the server list has not populated yet.  You may need to refresh the account", "","warning");
        }
      },
      err => {
        console.log("apierror: " + err);
        this.progressBarDialog.close();

        if (err.status == 404){ //account not found in patchingAccounts table
          //show error -- not opted in
          this.errorDialog.open(this.title, "Account is not opted in", "","warning");
        }
        else{
          this.errorDialog.showError(this.title, err,"","error");
        }
      });
  }

  GetPatchingClients(){
    if (this.servers.length == 0){
      this.errorDialog.open(this.title, "no servers found for this account.  You may need to Opt-In the account or refresh the account server list", '', 'error')
    }
    else{
      this.progressBarDialog.open("Searching for Patches", "determinate" );
      this.itemsComplete = 0;
      this.totalItems = this.servers.length;


    this.report = new Array<ReportLine>();
    
      from(this.servers)
        .pipe(
          mergeMap(s => this.patching.getPatchingClient(s.deviceNumber), 100)
        )
        .subscribe( pc => {
          var i = this.servers.findIndex( s => s.deviceNumber == pc.deviceNumber);
          this.servers[i] = pc;
          this.FindPatchesForServer(pc);
        },
        err => {
          console.log("apierror: " + err);
          this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
          this.progressBarDialog.updateProgress(this.pctComplete, "");        },
        () => {
            console.log('GetPatchingClients() complete event');
            console.log("itemsComplete:" + this.itemsComplete + "/" + this.totalItems + " = " + this.pctComplete);
          }

        );
    }//else
  }

  stateChanged(e){
    //console.log(e);
    this.paramIncludeStates = e.value.join(',');
  }

  fromDateChange(e){
    if (e.value == null)
    {
      this.paramFrom = null;
    }
    else
    {
      this.paramFrom = this.formatDate(e.value);
    }
    
  }
  toDateChange(e){
    if (e.value == null)
    {
      this.paramTo = null;
    }
    else
    {
      this.paramTo = this.formatDate(e.value);
    }
  }

  formatDate(d: Date){
    var options = {   
      day: '2-digit',
      month: '2-digit',
      year: 'numeric'
    };
  
    var dt = d.toLocaleDateString('en-US', options); 
    console.log(dt );

    var dt = dt.replace("/", "-").replace("/","-");
    return dt;
  }

  FindPatchesForServer(svr: PatchingClient){
    console.log("  FindPatchesForServer(" + svr.name + ") starting");
    this.patching.findPatches(svr.deviceNumber, this.paramFrom, this.paramTo, this.paramIncludeStates, this.paramExcludeStates)
      .subscribe( 
        api  => {
          if (api.count == 0){
            this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
            this.progressBarDialog.updateProgress(this.pctComplete, "");

            if ( (this.pctComplete >= 100) ){
              console.log("FindPatchesForServer: 100%");
              this.progressBarDialog.close();
              this.dsReport = new MatTableDataSource(this.report);
              this._sort.active = "name";
              this._sort.direction = "asc";
              this.dsReport.sort = this._sort;
              this.showForm = true;
            }
          }
          else{
            this.row = this.BuildReportRow(svr);
            this.report.push(this.row);
            this.GetPatchDetails(svr,api)
          }
        },
        err => {
          console.log("apierror: " + err);
          this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
          this.progressBarDialog.updateProgress(this.pctComplete, "");
        },
        () => {
          console.log('FindPatchesForServer() complete event');
          console.log("itemsComplete:" + this.itemsComplete + "/" + this.totalItems + " = " + this.pctComplete);
        }
      );
  }


  GetPatchDetails(client: PatchingClient, api:ApiCollection){
   // var counter = 0;
    console.log("  GetPatchDetails(" + client.name + ") starting");
    from(api.resources) //foreach url in the resources array
    .pipe(
      mergeMap( url => this.patching.getPatchDetailByURL(url), 100)
    )
      .subscribe(
        p => { //PatchStatus
          var i = this.report.findIndex( r => r.wsusID == p.wsusId);
          this.report[i].patches.push(p);
        },
        error => {
          console.log("apierror" + error);
          this.errorDialog.showError(this.title, error,"","error");
        },
        () => { 
          console.log("  GetPatchDetails() complete event");
          //all patches added to the row, add the row to the report object
          this.row.patches.sort( (a,b) => {
            if (a.title > b.title) {return 1};
            if (a.title < b.title) {return -1};
            
            return 0; //just in both are identical
          });

          this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
          this.progressBarDialog.updateProgress(this.pctComplete, client.name);
          console.log("   itemsComplete:" + this.itemsComplete + "/" + this.totalItems + " = " + this.pctComplete + "%");

          if (this.pctComplete >= 100) {
            console.log("GetPatchDetails: 100%");
            this.progressBarDialog.close();
            this.dsReport = new MatTableDataSource(this.report);
            this._sort.active = "name";
            this._sort.direction = "asc";
            this.dsReport.sort = this._sort;
            this.showForm = true;
          }
        }
      );
  }

  BuildReportRow(svr: PatchingClient): ReportLine{
    let row = new ReportLine();


    row.deviceNumber = svr.deviceNumber;
    row.wsusID = svr.wsusid;
    row.name = svr.name;
    row.patchingLevel = svr.patchingLevel;
    row.unSupportedOS = svr.unSupportedOS;  // set based on os version numbers

    return row;
  }


  exportCSV(filename) {
    var csv = "Server, Patching Level, Patch Severity, State, Patch Name\n"
    var col = "";
    var badOS = "This server is running an older OS version that is no longer supported by Microsoft and does not receive new security updates.";

    this.dsReport.data.forEach((record, j) => {
        if (record.patches.length == 0){
          csv += '"' + record.name + '",,,' + badOS + ',\n';
        }
        else
        {
          for (let p of record.patches)
          {
            csv += '"' +  record.name + '",';
            switch(record.patchingLevel){
              case 0: {csv += '"None",'; break; }
              case 1: {csv += '"Basic",'; break; }
              case 2: {csv += '"Advanced",'; break; }
              case 3: {csv += '"Manual",'; break; }
            };

            csv += '"' + p.severity + '",';
            csv += '"' + p.state + '",';
            csv += '"' + p.title + '"';
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
