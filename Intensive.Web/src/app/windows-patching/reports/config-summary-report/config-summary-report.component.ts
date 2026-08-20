
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
// import { Observable,  } from 'rxjs';
// import { DataSource } from '@angular/cdk/collections';
// import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import {MatDialog,
        MatTableDataSource,
        MatSort
      } from '@angular/material';

import { Subscription, from } from 'rxjs';
import { interval } from 'rxjs';
import { mergeMap, finalize } from 'rxjs/operators';

import { AccountService, AccountData } from '../../../lib/account';
import { CachingService } from '../../../lib/caching';
import { AuthData } from '../../../lib/auth';

import { PatchingAccount } from '../../../windows-patching/models/patching-account';
import { PatchingClient, PatchingAdvancedConfig } from '../../../windows-patching/models/patching-client';
import { WinPatchService } from '../../../windows-patching/win-patch.service';
import { ErrorDialog } from '../../../lib/error-dialog';
import { ProgressBarDialog } from '../../../lib/progress-bar-dialog';

import {ReportLine} from './report-line';

@Component({
  selector: 'app-config-summary-report',
  templateUrl: './config-summary-report.component.html',
  styleUrls: ['./config-summary-report.component.css']
})
export class ConfigSummaryReportComponent implements OnInit, AfterViewInit {

  account: AccountData;
  patchingAccount: PatchingAccount;
  servers: PatchingClient[];

  //newAccount:boolean; //indicates that the current account has never been opted in

  report: ReportLine[] = new Array();
  dsReport = new MatTableDataSource([]);


  columns: string[] = ['name', 'dataCenter', 'patchingLevel', 'action', 'scheduledWeek', 'schedule' ];

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
    this.patchingAccount = new PatchingAccount();
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
    this._sort.active = "name";

    this.dsReport.sort = this._sort;
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
          },
          err => {
            console.log("apierror: " + err);
            this.progressBarDialog.close();

            if (err.status == 404){ //account not found in patchingAccounts table
              this.patchingAccount.optedOut = true;
            }
            else{
              this.errorDialog.open("Patching Account", err.message,"","error");
            }
          });
  }

  GetPatchingClients(){
    this.progressBarDialog.open("Loading Patching Client data", "determinate" );
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

        if (pc.errors.length>0){
          this.servers[index].statusMessage = pc.errors.join('\r\n');
          this.servers[index].statusIcon = "error";
          this.servers[index].statusIconColor = "darkred";
        }

        if (pc.optedOut){
          this.servers[index].statusIcon = "cancel";
          this.servers[index].statusIconColor = "darkred";
          this.servers[index].statusMessage = "This server has been OPTED OUT ";
        }
        this.report.push(this.BuildReportRow(this.servers[index]));

        this.itemsComplete++;
        this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
        this.progressBarDialog.updateProgress(this.pctComplete,"");
        
      },
      err => {
        console.log("apierror: " + err)
      },
      () => {
        // this.itemsComplete++;
        // this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
        // this.progressBarDialog.updateProgress(this.pctComplete,"");
        if (this.pctComplete >= 100) {
          this.showForm = true;
          this.progressBarDialog.close();

          this.dsReport = new MatTableDataSource(this.report);
          this._sort.active = "name";
          this.dsReport.sort = this._sort;
        }
    })
  }

  // GetPatchingClient(num){
  //   this.patching.getPatchingClient(num)
  //         .subscribe( pc => {
  //               let index = this.servers.findIndex(d => d.deviceNumber === pc.deviceNumber);
  //               this.servers[index] = pc;

  //               if (pc.errors.length>0){
  //                 this.servers[index].statusMessage = pc.errors.join('\r\n');
  //                 this.servers[index].statusIcon = "error";
  //                 this.servers[index].statusIconColor = "darkred";
  //               }

  //               if (pc.optedOut){
  //                 this.servers[index].statusIcon = "cancel";
  //                 this.servers[index].statusIconColor = "darkred";
  //                 this.servers[index].statusMessage = "This server has been OPTED OUT ";
  //               }
  //               this.report.push(this.BuildReportRow(this.servers[index]));
  //             },
  //             err => {
  //               console.log("apierror: " + err)
  //             },
  //             () => {
  //               this.itemsComplete++;
  //               this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
  //               this.progressBarDialog.updateProgress(this.pctComplete,"");
  //               if (this.pctComplete >= 100) {
  //                 this.showForm = true;
  //                 this.progressBarDialog.close();

  //                 this.dsReport = new MatTableDataSource(this.report);
  //                 this._sort.active = "name";
  //                 this.dsReport.sort = this._sort;
  //               }
  //         })
  // }


  // EditConfig(device){
  //   let segments = [this.account.number, 'patching','config'];
  //   let qs = { queryParams: { select: device } }
  //   this.router.navigate(segments, qs);
  // }


  BuildReportRow(svr: PatchingClient): ReportLine{

    var patchingLevels = ['None', 'Basic', 'Advanced', 'Manual'];
    var releaseWeeks = ['','Early','Default','Delayed'];
    var dayNames = ['Every Day','Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
    var actions = [ "",
                    "",
                    "Notify BEFORE downloading",
                    "Notify AFTER downloading",
                    "Automatic Download and install",
                    "User can configure"
                  ];
    let row = new ReportLine();

    row.statusIcon = svr.statusIcon;
    row.statusIconColor = svr.statusIconColor;
    row.statusMessage = svr.statusMessage;
    row.deviceNumber = svr.deviceNumber;
    row.name = svr.name;
    row.dataCenter = svr.dataCenter;
    row.patchingLevel = patchingLevels[svr.patchingLevel];

    if (svr.patchingLevel == 2){  //advanced patching
      row.action = svr.advancedPatching.processName;
      // row.schedule = svr.advancedPatching.minute + ' ' +
      //               svr.advancedPatching.hour + ' ' +
      //               svr.advancedPatching.dayOfWeek + ' ' +
      //               svr.advancedPatching.dayOfMonth + ' ' +
      //               svr.advancedPatching.monthOfYear;
      row.schedule = this.AdvancedScheduleToString(svr.advancedPatching);
    }
    else{
      row.action = actions[svr.auOptions];
      row.schedule = dayNames[svr.scheduledDay] + ' at ' + svr.scheduledTime + ':00';
    }

    row.scheduledWeek = releaseWeeks[svr.scheduledWeek]

    row.errors = svr.errors;

    return row;
  }

  ShowAuditTrail(device){
    let segments = ['audit'];
    let qs = { queryParams: { systemid: 14, device: device } }
    this.router.navigate(segments, qs);
  }

  exportCSV(filename) {
    let data = this.report;
    var csv = this.columns.join(',');
    var col = "";

    data.forEach((record, j) => {
        csv += '\n';
        for (let i = 0; i < this.columns.length; i++) {
            col = this.columns[i];
            csv += '"' + record[col] +'"';  //double quotes around the column data to capture embedded quotes and commas

            if (i < (this.columns.length - 1)) {
                csv += ',';
            }
        }
    });

    this.DownloadFile(csv, filename);
  }

  AdvancedScheduleToString(sched: PatchingAdvancedConfig): string{
    var days = ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"]
    var week;
    var d;
    var t;
    switch(sched.dayOfMonth){
      case "1-7": week = "1st "; break;
      case "8-14": week = "2nd "; break;
      case "15-21": week = "3rd "; break;
      case "22-28": week = "4th "; break;
      case "25-31": week = "Last "; break;
    }

    d = days[sched.dayOfWeek];

    var hh, mm;

    if (+sched.hour < 10){
      hh = "0" + sched.hour;
    }
    else{
      hh = sched.hour;
    }

    if (+sched.minute < 10){
      mm = "0" + sched.minute;
    }
    else{
      mm = sched.minute;
    }
    t = hh + ':' + mm + " UTC";

    return week + d + " at " + t;
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




