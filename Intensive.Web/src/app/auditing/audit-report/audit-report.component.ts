import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute, Params, ActivationEnd } from '@angular/router';
import {FormControl, FormBuilder, Validators, FormGroupDirective, NgForm} from '@angular/forms';

import { Observable,  } from 'rxjs';

import 'rxjs/add/observable/merge';


//import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import {MatDialog, 
  MatDialogRef, 
  MatDialogConfig,
  MatTableDataSource,
  MatSort
} from '@angular/material';

import { CachingService } from "../../lib/caching/caching.service";
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { AuditingService } from '../auditing.service';
import { AuditEntry } from '../audit-entry';
import { AccountService, AccountData } from '../../lib/account';


@Component({
  selector: 'app-audit-report',
  templateUrl: './audit-report.component.html',
  styleUrls: ['./audit-report.component.css']
})
export class AuditReportComponent implements OnInit {


  systemIdFilter: number;
  deviceNumberFilter: number;
  accountFilter: number;
  useridFilter: string;
  actionFilter: string;

  ds = new MatTableDataSource([]);
  pct;
  contentHeight: number;

  account: AccountData;
  

  auditEntry: AuditEntry;
  auditEntries: Array<AuditEntry> = new Array<AuditEntry>();
  
  columns: string[] = ['systemName', 'account', 'deviceNumber', 'userId', 'action', 'timeStamp'];
  exportColumns: string[] = ['systemName', 'account', 'deviceNumber', 'userId', 'action', 'detail', 'timeStamp'];

  
  errorDialog: ErrorDialog;
  progressDialog: ProgressBarDialog;

  qryString: Params;

  systemIdNumbers: number[] = [14, 11];
  systemNames: string[] = ["Windows Patching", "Active Directory"];
  
  @ViewChild(MatSort, {static: false}) _sort: MatSort;

  constructor( private router: Router, 
              private route: ActivatedRoute,
              private auditService: AuditingService,
              private dlgError: MatDialog,
              private dlgProgress: MatDialog,
              private cache: CachingService
  ) {  
    console.log("AuditReportComponent: constructor()");
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.progressDialog = new ProgressBarDialog(this.dlgProgress);

    this.router.events.subscribe(evt => {
      if ( (evt instanceof ActivationEnd) && (evt.snapshot.component)) {
            this.ProcessQueryString();
          }
        });
    this.cache.hideAccount();
  }

 

  ngOnInit() {
    this.contentHeight = window.innerHeight - 72;  //toolbar height with margin
   }


   ngAfterViewInit(){
    console.log("matsort:" + this._sort);
  }

   ProcessQueryString(){
    this.route.queryParams.subscribe((p: Params) => {

      let qs = {};

      //copy querystring params to local variable, convering the keys to all lowercase
      Object.keys(p).forEach(k=> qs[k.toLowerCase()] = p[k]);
      this.qryString = qs;

      if (this.qryString.systemid){
        this.systemIdFilter = this.qryString.systemid;
      }

      if (this.qryString.account){
        this.accountFilter = this.qryString.account;
      }

      if (this.qryString.device){
        this.deviceNumberFilter = this.qryString.device;
      }

      if (this.qryString.sso){
        this.useridFilter = this.qryString.sso;
      }

      if (this.qryString.action){
        this.actionFilter = this.qryString.action;
      }

      //this.FilterAuditData();
        
    });
   }

   ResetFilters(){
    this.systemIdFilter = -1;
    this.deviceNumberFilter = null;
    this.useridFilter = null;
    this.actionFilter = null;
    this.auditEntries = new Array<AuditEntry>();
    this.ds = new MatTableDataSource(this.auditEntries);
    this._sort.active = "timeStamp";
    this._sort.direction = "desc";
    this.ds.sort = this._sort;
    return false;
   }
  
  FilterAuditData(){
    // this.auditEntries = new Array();
    // this.ds = new MatTableDataSource<AuditEntry>(this.auditEntries);
    // this.ds.sort = this._sort;
    if (this.ValidFilter()){
      
      this.progressDialog.open("Audit Trail Report", "indeterminate");
      this.progressDialog.updateProgress(null, "Searching for matching data....");
      
      this.auditService.FindAuditEntries(this.systemIdFilter,
                                        this.accountFilter,
                                        this.deviceNumberFilter,
                                        this.useridFilter,
                                        this.actionFilter
                                      )
        .subscribe(
          a => { 
            if (a.count == 0){  //no matching resources
              this.progressDialog.close();  
            }
            else{
              this.GetAuditData(a);
            }

          },
          err => {
            this.progressDialog.close();
            this.errorDialog.showError("Audit Trail", err,"","error");
          }
        );
    } //if validFilter
  }


  GetAuditData(api){
    let dcs: string[] = [];
    let items:number = 0;
    this.pct = 0;
    
      this.progressDialog.open("Audit Trail Report", "determinate");
      this.progressDialog.updateProgress(this.pct, "Loading.....");
    
      this.auditEntries = new Array<AuditEntry>();

      for(let url of api.resources){
        this.auditService.GetAuditURL(url)
          .subscribe(
            a => { 
              var i = this.systemIdNumbers.indexOf(+a.systemId);
              a.systemName = this.systemNames[i];
              a.arrDetails = new Array();

              if ( (a.detail != undefined) && (a.detail != null) )
              {
                if (a.detail.indexOf("\r\n") > -1){
                    a.arrDetails = a.detail.split('\r\n')
                    //a.arrDetails.pop(); //pop the last(empty) entry
                }
                else{
                  a.arrDetails.push(a.detail);
                }
              }
              this.auditEntries.push(a);
            },

            err => {console.log(err)},

            () => { 
              this.pct = Math.floor(((++items)/api.count)*100)
              this.progressDialog.updateProgress(this.pct, "Loading.....");
              
              if (this.pct >= 100)   {
                this.progressDialog.close();
                this.ds = new MatTableDataSource(this.auditEntries);
                this._sort.active = "timeStamp";
                this._sort.direction = "desc";
                this.ds.sort = this._sort;
              } //if pct > 100
            }// () =>
          ); //subscribe
      }
  }

  ValidFilter(){
    var ok = true;
    if (this.systemIdFilter != -1){
        var i = this.systemIdNumbers.indexOf(+this.systemIdFilter);
        if ((this.systemIdFilter) && (this.systemIdNumbers.indexOf(+this.systemIdFilter)<0)){
          this.errorDialog.showError("Audit Trail Report", "Not a valid System ID number","","error");
          return false;
        }
    }
    return ok;
  }



  exportCSV(filename) {
    //let data = this.ds.getSortedData();
    let data = this.ds.data;
    var csv = this.exportColumns.join(',');
    var col = "";

    data.forEach((record, j) => {
        csv += '\n';
        for (let i = 0; i < this.exportColumns.length; i++) {
            col = this.exportColumns[i];
                csv += '"' + record[col] +'"';  //double quotes around the column data to capture embedded quotes and commas
                if (i < (this.exportColumns.length - 1)) {
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

// export class TableData {
//   dataChange: BehaviorSubject<AuditEntry[]> = new BehaviorSubject<AuditEntry[]>([]);
//   get data(): AuditEntry[] { return this.dataChange.value; }

//   constructor (dataArray:AuditEntry[]){
//     this.dataChange.next(dataArray);
//   }
// }

// export class TableDataSource extends DataSource<any>{
  
//   constructor(private _data: TableData) {
//     super();
//   }
  


//   connect(): Observable<AuditEntry[]> {
//     const displayDataChanges = [
//       this._data.dataChange,
//       //this._sort.mdSortChange
//       //this._filterChange
//     ];

//     return Observable.merge(...displayDataChanges).map(() => {
//       return this.getSortedData();
//     });
//   }

//   disconnect() {}

//   getSortedData(): AuditEntry[] {

//     const data = this._data.data.slice();
  
//     return data.sort( (a,b) =>{
//       if (a.timeStamp > b.timeStamp) return -1;
//       if (a.timeStamp < b.timeStamp) return 1
//       return 0;
//     });;
//   }
// }

