import { Component, OnInit, Input, OnChanges } from '@angular/core';
import {
  Router,
  ActivatedRoute,
  Params,
  ActivationStart
} from "@angular/router";
import { MatDialog, MatDialogRef, MatDialogConfig } from "@angular/material";
import { from, Observable, forkJoin, of} from 'rxjs';
import { mergeMap, filter, merge, catchError } from 'rxjs/operators';
import { AuthService } from '../../lib/auth';
import { environment } from '../../../environments/environment';
import { rackspaceADService } from '../../lib/rsad';
import { ActiveDirectoryService } from '../active-directory.service' ;
import { AdUser, AdCustomerAccess, AdGeneratedPassword } from '../models';
import { CachingService } from "../../lib/caching/caching.service";
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { AuthData } from '../../lib/auth';
import { ApiError, AppConfigService, ApiCollection } from '../../lib/shared-data'

@Component({
  selector: 'ss-customer-access',
  templateUrl: './customer-access.component.html',
  styleUrls: ['./customer-access.component.css']
})
export class CustomerAccessComponent implements OnInit, OnChanges {

  user: AdUser;

  title:string = "Customer Access";
  keys: string[];

  componentHeight: number = 0;

  accountNumbers: string;
  selectedAccounts: string;
  adCustAccess: AdCustomerAccess;
  results = new ApiCollection();

  grantDisabled: boolean;
  renewDisabled: boolean;
  revokeDisabled: boolean;


  sso: string;
  authData: AuthData;
  empid: string;
  showForm: boolean = false;
  filter: string;
  errorDialog: ErrorDialog;
  progressDialog: ProgressBarDialog;
  totalItems: number;
  itemComplete: number;
  pctComplete: number;

  adConfig: any;


  constructor( private router: Router,
              private ad: ActiveDirectoryService,
              private rsad: rackspaceADService,
              private cache: CachingService,
              private dlgError: MatDialog,
              private dlgProgress: MatDialog,
              private config: AppConfigService
            ) {
     
    this.componentHeight = window.innerHeight - 80;
    this.user = null;
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.progressDialog = new ProgressBarDialog(this.dlgProgress);

    this.authData = this.cache.authData;
    this.selectedAccounts = '';

    this.adConfig = this.config.getConfig("ad");
            
    this.accountNumbers = '';
  }

  ngOnInit() {
    this.progressDialog.open(this.title,'indeterminate');
    this.progressDialog.updateProgress(0,"Getting your Rackspace SSO....")

    // this.ad.GetGroupURL("https://test.api.selfservice.intensive.int/ad/v1/domains/intensive/groups/1103359-RAX")
    //   .subscribe(
    //     grp => this.errorDialog.open("GRP URL TEST", JSON.stringify(grp),"","error"),
    //     err => this.errorDialog.showError("GRP URL TEST", err,"","error")
    //   );
    
    //call rackspace AD api to get employeeid
    this.rsad.GetUser(this.authData.sso, this.authData.token)
      .subscribe(
          u=> {
            this.sso = u.data.uid;
            this.empid = u.data.employeeID;

            this.filter = "(&(employeeid=" + this.empid + ")(samaccountname=*.cust))";
            this.progressDialog.close();
            this.showForm = true;
            this.progressDialog.updateProgress(0,"Finding your INTENSIVE credentials....")
          },
          err => {
            this.progressDialog.close();
            this.errorDialog.showError(this.title, err,"","error");
          }
      );
  }

  ngOnChanges(){
    console.log("CustomerAccess.ngOnChanges()");
  }

  routeTo(segments, qs) {
    if (segments.length<=1){
      this.cache.account = null;
    }
    this.router.navigate(segments, qs);
  }

  GrantAccess(){
    let accts = new Array<string>();

    if (this.ValidAccountInput())
    {
      //parse input into an array of account numbers
     
      accts = this.ParseAccountInput();

      this.progressDialog.open(this.title,"determinate");
      this.progressDialog.updateProgress(0, "Granting access....");
      this.itemComplete = 0;
      this.totalItems = accts.length;
      accts.forEach( (v,i, arr) => {
        this.ad.GrantCustomerAccess(this.user.userId, v.trim()) 
            .subscribe(
              x =>{
                  this.pctComplete = Math.floor((++this.itemComplete/this.totalItems)*100);
                  this.progressDialog.updateProgress(this.pctComplete, "Granting access to customer environment(s)...");

                  if (this.pctComplete >= 100){
                    this.progressDialog.close();
                    this.accountNumbers = '';
                    this.LoadUser();//refresh data
                  }
                  if (x.length > 0){
                    var results = x as Array<string>;
                    var msg = results.join("; ");
                    if (msg.indexOf("Error") > -1){
                      this.errorDialog.open(this.title, msg,"","error");    
                    }
                  }

                },
              err => {
                this.progressDialog.close();
                this.errorDialog.showError(this.title, err,"","error");
              }
            );
      }); //foreach
    }
  }

  ValidAccountInput():boolean {
    var valid: boolean = true;
    let accts = new Array<string>();
    let acctNumber: number;


    if (!this.accountNumbers){
      this.errorDialog.showError(this.title, "You must enter at least one account number","", "error");
      return false;
    }

    accts = this.ParseAccountInput();

    if (accts.length == 0) {
      this.errorDialog.open(this.title,"Enter one or more valid account numbers","","error");
      return false;
    }
    
    accts.forEach( a => {
      acctNumber = +a.trim();  //coerce string into a number

      if (isNaN(acctNumber)){
        this.errorDialog.open(this.title,"'" + a + "' is not a valid account number","","error");
        valid = false;
      }
    });

    return valid;
  }

  ParseAccountInput():Array<string>{
    let acctLines: string[];
    let accts = new Array<string>();
    acctLines = this.accountNumbers.split('\n');
    acctLines.forEach( line => {
      if (line != ''){            //skip empty lines
        if (line.includes(",")){  //parse accounts on same line, separated by commas
          var parts = line.split(','); 
          accts = accts.concat(parts);
        }
        else{
          accts.push(line);     //single account number on the line; just add it to the list
        }
      }
    });
    return accts;
  }


  RenewAccess(){
    //Udpate the expiration time
    //Just call the GrantAccess method
    //
    //The backend process is the same, whether it's the 
    //first grant or a renewal

    if ( (!this.selectedAccounts) || (this.selectedAccounts == '') ){
      this.errorDialog.showError(this.title, "You must select at least one account number from the list","", "error");
      return;
    }
    else{
      this.accountNumbers = this.selectedAccounts;
      this.GrantAccess();
    }
  }

  RevokeAccess(){
    let accts: string[];
    
    if (this.selectedAccounts.length == 0){
      this.errorDialog.showError(this.title, "You must select at least one account number from the list","", "error");
      return;
    }

    this.accountNumbers = this.selectedAccounts;

    accts = this.ParseAccountInput();

    this.progressDialog.open(this.title,"indeterminate");
    this.progressDialog.updateProgress(0, "Revoking access....");
    this.itemComplete = 0;
    this.totalItems = accts.length;
    accts.forEach( (v,i, arr) => {
      this.ad.RevokeCustomerAccess(this.user.userId, v.trim()) 
          .subscribe(
            x =>{
                this.pctComplete = Math.floor((++this.itemComplete/this.totalItems)*100);
                this.progressDialog.updateProgress(this.pctComplete, "Revoking access to customer environment(s)...");

                if (this.pctComplete >= 100){
                  this.progressDialog.close();
                  this.accountNumbers = '';
                  this.LoadUser();//refresh data
                }
              },
            err => {
              this.progressDialog.close();
              this.errorDialog.showError(this.title, err,"","error");
            }
          );
    }); //foreach
  }

  UserSelected(evt){
    this.user = evt.user;
    this.LoadUser();
  }

  LoadUser(){
    this.grantDisabled = false;
    this.renewDisabled = false;
    this.revokeDisabled = false;

    
    //this.progressDialog.open(this.title,'indeterminate');
    //this.progressDialog.updateProgress(0,"Getting Customer Access list....")
    
    this.ad.GetUser(this.user.domainName, this.user.userId, "rsactiveaccess,accountexpires")
        .subscribe(
          u=> {
            console.log("  rsactiveaccess=" + u.attributes['rsactiveaccess']);
            this.adCustAccess = JSON.parse(u.attributes['rsactiveaccess']);

            console.log(this.adCustAccess);

            this.keys = Object.keys(this.adCustAccess);
            console.log("  keys:" + this.keys)

            if ( (!u.enabled) || (u.lockedOut) || (this.isExpired(u)) ){
              this.grantDisabled = true;
              this.renewDisabled = true;
              this.revokeDisabled = false;
            }
            //this.progressDialog.close();
          },
          err => {
            //this.progressDialog.close();
            this.errorDialog.showError(this.title, err,"","error");
          }
      );
    
  }

  UserListLoaded(users){
    //called when the user list finishes loading
  }

  SelectionChange(evt){
    console.log(evt);
    var selectedObjects = evt.source.selectedOptions.selected;
    this.selectedAccounts = '';
    selectedObjects.forEach(s => {
      if (this.selectedAccounts == ''){
        this.selectedAccounts += s.value;
      }
      else{
        this.selectedAccounts += '\n' + s.value;
      }
    })
    
  }

  isExpired(user){
    var dt = user.attributes["accountexpires"];
    var expDate = this.FileTimeToDate(dt);

    var dtNow = new Date(Date.now());

    return expDate < dtNow;
  }

  FileTimeToDate(filetime: number): Date {
    return new Date (filetime/10000 - 11644473600000 );
  }
}
