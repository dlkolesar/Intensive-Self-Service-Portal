
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import {MatDialog, 
        MatTableDataSource,
        MatSort
      } from '@angular/material';

import { AccountService, AccountData } from '../../lib/account';
import { CachingService } from '../../lib/caching';
import { AuthData } from '../../lib/auth';

import { PatchingAccount } from '../../windows-patching/models/patching-account';
import { PatchingClient } from '../../windows-patching/models/patching-client';
import { WinPatchService } from '../../windows-patching/win-patch.service';
import { ErrorDialog } from '../../lib/error-dialog';
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';

import { ReportLine } from './report-line';

@Component({
  selector: 'ss-win-patch-dashboard',
  templateUrl: './win-patch-dashboard.component.html',
  styleUrls: ['./win-patch-dashboard.component.css']
})
export class WinPatchDashboardComponent implements OnInit, AfterViewInit {

  account: AccountData;
  patchingAccount: PatchingAccount;
  servers: PatchingClient[];
  accountNotFound: boolean;
  dashboard: ReportLine[];

  ds = new MatTableDataSource([]);

      
  columns: string[] = ['name', 'dataCenter', 'patchingLevel', 'lastContact', 'lastPatchDate', 'nextPatchDate', 'errors' ];
  
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
    this.dashboard = new Array<ReportLine>();
  }

  @ViewChild(MatSort, {static: false}) _sort: MatSort;

  ngOnInit() {
    console.log("win-patch.component: OnInit()");
    this.contentHeight = window.innerHeight - 72;  //toolbar height with margin


    this.account = this.cache.account;
    //this.servers = this.account.servers.filter(s => s.wsusid != null && s.wsusid != '00000000-0000-0000-0000-000000000000') as PatchingClient[];
    this.servers = this.account.servers as PatchingClient[];
    
    this.GetPatchingAccount();
    

  }

  ngAfterViewInit(){
    console.log("matsort:" + this._sort);
  }
  
  ngOnDestroy(){
  }
  

  GetPatchingAccount(){
    this.progressBarDialog.open("Patching Dashboard", "indeterminate" );

    this.patching.getPatchingAccount(this.account.number)
          .subscribe( pa => {
           // this.progressBarDialog.close();
            this.patchingAccount = pa;
            this.accountNotFound = false;
            //if ((!this.patchingAccount.optedOut)&&(this.servers.length>0) ){
            if (this.servers.length == 0){
              this.pctComplete = 100;
              this.progressBarDialog.close();
            }
            else{
              this.GetPatchingClients();
            }
          },
          err => {
            console.log("apierror: " + err);
            this.progressBarDialog.close();

            if (err.status == 404){ //account not found in patchingAccounts table
              //show error -- not opted in
              this.errorDialog.open("Patching Dashboard", "'" + this.account.number + "' is a valid CORE account number, but it has never been opted IN.  To view the Dashboard for this account, please navigate to the Configuration page and opt the account in.","","error");
            }
            else{
              this.errorDialog.showError("Patching Dashboard", err,"","error");
            }
          });
  }

  GetPatchingClients(){
    this.progressBarDialog.open("Loading Patching Client data", "determinate" );
    this.itemsComplete = 0;
    this.totalItems = this.servers.length;
    this.servers.forEach( (svr, idx, arr) =>{
      this.GetPatchingClient(svr.deviceNumber);
    });
    
  }

  GetPatchingClient(num){
    let row: ReportLine;

    this.patching.getPatchingClient(num)
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
                row = new ReportLine(pc);
                this.dashboard.push(row);
              },
              err => {
                console.log("apierror: " + err)
              },
              () => {
                this.itemsComplete++;
                this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
                this.progressBarDialog.updateProgress(this.pctComplete,"");
                if (this.pctComplete >= 100) {
                  this.showForm = true;
                  this.progressBarDialog.close();

                  this.ds = new MatTableDataSource(this.dashboard);
                  this._sort.active = "name";
                  this.ds.sort = this._sort;
                }
          })
  }


  EditConfig(device){
    let segments = [this.account.number, 'windowspatching','config'];
    let qs = { queryParams: { select: device } }
    this.router.navigate(segments, qs);
  }

  exportCSV(filename) {
    let data: PatchingClient[] = this.ds.data;
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
