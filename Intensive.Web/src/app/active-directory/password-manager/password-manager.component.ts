import { Component, OnInit, Input, Output, OnChanges, EventEmitter } from '@angular/core';
import {
  Router,
  ActivatedRoute,
  Params,
  ActivationStart
} from "@angular/router";
import { MatDialog, MatDialogRef, MatDialogConfig } from "@angular/material";
import { from, forkJoin } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

import { environment } from '../../../environments/environment';

import { ActiveDirectoryService } from '../active-directory.service' ;
import { AdUser, AdGeneratedPassword } from '../models';
//import { vmUser } from '../ad-user-select/ad-user-select.component';
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { AuthService } from '../../lib/auth';
import { eDirService, eDirUser } from '../../lib/edir';
import { ApiError, AppConfigService } from '../../lib/shared-data';
import { rackspaceADService } from '../../lib/rsad';
import { AuthData } from '../../lib/auth';
import { CachingService } from "../../lib/caching/caching.service";

@Component({
  selector: 'ss-password-manager',
  templateUrl: './password-manager.component.html',
  styleUrls: ['./password-manager.component.css']
})

export class PasswordManagerComponent implements OnInit, OnChanges {
  user: AdUser;
  config: any;

  //view model
  adPwd: AdGeneratedPassword;
  componentHeight: number = 0;

  //accountIsExpired: boolean;
  filter: string;
  sso: string;
  empid: string;
  showForm: boolean = false;

  dialogTitle: string = "Password Manager";
  authData: AuthData;
  qsUserid:string;

  //local variables
  progressDialog: ProgressBarDialog;
  errorDialog: ErrorDialog;
  pctComplete: number;
  itemsComplete: number;
  totalItems: number;
  domainsTotal: number;
  domainsSearched: number;

  constructor( private router: Router,
              private route: ActivatedRoute,
              private auth: AuthService,
              private ad: ActiveDirectoryService,
              private rsad: rackspaceADService,
              private cache: CachingService,
              private dlgProgress: MatDialog,
              private dlgError: MatDialog,
              private cfgSvc: AppConfigService
            ) {
     
    console.log("password-manager.component: constructor()");
    //this.config = this.cfgSvc.config["ad"]["passwordManager"];

    this.componentHeight = window.innerHeight - 96;
    this.adPwd = new AdGeneratedPassword();
    this.progressDialog = new ProgressBarDialog(dlgProgress);
    this.errorDialog = new ErrorDialog(dlgError);
    this.cache.hideAccount();
    this.authData = this.cache.authData;

    this.route.queryParams.subscribe((p: Params) => {
      if (p["userid"]){
        this.qsUserid = p["userid"];
      }
      else{
        this.qsUserid = '';
      }
    });
    this.user = new AdUser();
  }

  ngOnInit() {
    console.log("password-manager.component: OnInit()");

    this.progressDialog.open(this.dialogTitle,'indeterminate');
    this.progressDialog.updateProgress(0,"Getting your Rackspace SSO....")
    
    //call rackspace AD api to get employeeid
    this.rsad.GetUser(this.authData.sso, this.authData.token)
      .subscribe(
          u=> {
            // this.sso = u.sso;
            // this.empid = u.attributes["employeeid"];
            this.sso = u.data.uid;
            this.empid = u.data.employeeID;

            this.filter = "(employeeid=" + this.empid + ")";
            this.progressDialog.close();
            this.showForm = true;
          },
          err => {
            this.progressDialog.close();
            this.errorDialog.showError(this.dialogTitle, err,"","error");
          }
      );

  }

  ngOnChanges(){
    
  }

  UserSelected(evt){
    this.adPwd = new AdGeneratedPassword();
    this.user = evt.user;
    
  }

  UserListLoaded(users:AdUser[]){
    if (users.length == 0){
      this.errorDialog.open(this.dialogTitle, "Your SSO does not have any Intensive credentials associated with it. If you are certain that you have Intensive credentials contact Segment Support for assistance.","","warning");
    }
    if (this.qsUserid!= ''){
      console.log("auto-selecting user from list")
      this.user = users.find( u => u.userId.toLowerCase() == this.qsUserid.toLowerCase())||new AdUser();
      if (this.user.userId == ''){
        this.errorDialog.open(this.dialogTitle, "userid '" + this.qsUserid + "' does not exist or is not associated with your SSO","","error");
      }
    }
  }

  onGeneratePassword(){
    this.progressDialog.open(this.dialogTitle,'indeterminate');
    this.progressDialog.updateProgress(null, "Generating new password.....");
    this.ad.GenerateNewPassword(this.user.domainName, this.user.userId)
              .subscribe( p => {
                this.adPwd = p;
                var dtNow = new Date(this.adPwd.expires);

                var ft = this.DateToFileTime(new Date(this.adPwd.expires));

                console.log("exp: " + this.adPwd.expires.toLocaleString());
                
                this.user.attributes["accountexpires"] = ft;
                this.user.lockedOut = false;

                //this.user.attributes["accountexpires"] = p.expires;
                this.progressDialog.close();
                //this.changed.emit(this.user);
              },
              err => {
                this.progressDialog.close();
                this.errorDialog.showError(this.dialogTitle, err,"","error");
              });
  }

  onUnlockAccount(){
    this.user.lockedOut = false;

    // Javascript cannot convert/store the very large number that represents the accountExpires value
    // but the API can, therefore the API always thinks that the account expiration is changing, and throws an error
    // because the value passed in(from javascript) does not convert to a proper value;

    // so, since we are just unlocking the account and not changing the account expiration
    // just save off the value, delete the "accountexpires" attribute from the data passed in to the API,
    // then restore the value so it displays correctly in the UI
    //
    //ahhh... the joys of working with javascript....
    //
    var exp = this.user.attributes["accountexpires"]; //save the value
    delete this.user.attributes["accountexpires"];    //delete the attribute



    this.progressDialog.open(this.dialogTitle,'indeterminate');
    this.progressDialog.updateProgress(null, "Unlocking user account.....");

    this.ad.UpdateUser(this.user)
              .subscribe( d => {
                this.progressDialog.close();
                this.user.attributes["accountexpires"] = exp; //restore the value for the UI to display
              },
              err => {
                this.progressDialog.close();
                this.errorDialog.showError(this.dialogTitle, err,"","error");
              });
  }

  onExpireAccountNow(){

    var ftDate = this.DateToFileTime(new Date(Date.now()));

    this.user.attributes["accountexpires"] = ftDate.toString();
    this.progressDialog.open(this.dialogTitle,'indeterminate');
    this.progressDialog.updateProgress(null, "expiring user account.....");

    this.ad.UpdateUser(this.user)
              .subscribe( d => {
                this.progressDialog.close();
              },
              err => {
                this.progressDialog.close();
                this.errorDialog.showError(this.dialogTitle, err,"","error");
              });
  }

  FileTimeToDate(filetime: number): Date {
    return new Date (filetime/10000 - 11644473600000 );
  }

  DateToFileTime(dt:Date): number {
    return (dt.valueOf() + 11644473600000) * 10000;
  }

  isExpired(user){
    var dt = user.attributes["accountexpires"];
    var expDate = new Date ( dt / 10000 - 11644473600000 );

    var dtNow = new Date(Date.now());

    return expDate < dtNow;
  }
  
  getExpirationDate(){
   
    return new Date(this.FileTimeToDate(this.user.attributes["accountexpires"])).toLocaleString();
  }
}

