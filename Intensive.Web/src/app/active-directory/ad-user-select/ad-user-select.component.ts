import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChange } from '@angular/core';
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
import { AdUser } from '../models';
import { CachingService } from "../../lib/caching/caching.service";
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { AuthService } from '../../lib/auth';
import { eDirService, eDirUser } from '../../lib/edir';
import { ApiError, AppConfigService, ApiCollection } from '../../lib/shared-data'

@Component({
  selector: 'ss-ad-user-select',
  templateUrl: './ad-user-select.component.html',
  styleUrls: ['./ad-user-select.component.css']
})
export class AdUserSelectComponent implements OnInit, OnChanges {

  @Input() ldapFilter: string;
  @Input() selectedUser: AdUser;
  @Output() selectionChange = new EventEmitter<any>();
  @Output() afterLoaded = new EventEmitter<any>();

  config: any;

  //view model
  sso: string;
  empid: string;
  edirUser: eDirUser;
  users: AdUser[];
  usersSorted: AdUser[];
  
  

  componentHeight: number = 0;
  //accountIsExpired: boolean;

  //local variables

  errorDialog: ErrorDialog;
  pctComplete: number;
  itemsComplete: number;
  totalItems: number;
  domainsTotal: number;
  domainsSearched: number;

  constructor( private router: Router,
              private auth: AuthService,
              private ad: ActiveDirectoryService,
              private edir: eDirService,
              private cache: CachingService,
              private dlgError: MatDialog,
            ) {
     
    console.log("ad-user-select.component: constructor()");

    this.componentHeight = window.innerHeight - 136;
    this.users = new Array<AdUser>();
    this.selectedUser = new AdUser();
;
    this.errorDialog = new ErrorDialog(dlgError);


    //this.ldapFilter = "(givenname=dan)"
  }

  ngOnInit() {
    // console.log("ad-user-select.component: OnInit()");
    // this.GetADUserAccounts();
    
  }


  ngOnChanges(changes: {[propKey: string]: SimpleChange}){
    console.log("ad-user-select.component: OnChanges()");
    console.log(changes);
    console.log("filter: " + this.ldapFilter);
    if (this.ldapFilter != ''){
      this.GetADUserAccounts();
    }
  }

  GetADUserAccounts(){
    this.totalItems = 0;
    this.itemsComplete = 0;
    this.domainsTotal = environment.RackerDomains.length;
    this.domainsSearched = 0;
    this.pctComplete = 1;
  
    from(environment.RackerDomains) //foreach domain in the config
    .pipe(
      mergeMap( dom => this.ad.FindUsers(dom, this.ldapFilter))  //Find users in that domain
    )
    .subscribe( //subscribe to each result
        u => {
          if (u.count == 0){
            this.pctComplete = 100;
          }

          this.totalItems += u.count;
          this.domainsSearched++;
          
          //this.progressDialog.updateProgress(0,"Loading your user accounts....")
          this.users = new Array<AdUser>();

          u.resources.forEach( (url, idx, arr) => {
            this.GetUserByUrl(url);
          });
        },
        err => {
          this.errorDialog.showError("AD User Select", err,"","error");
        }
    )
  }

  GetUserByUrl(url){
    this.ad.GetUserURL(url + '?attributes=accountexpires')
      .subscribe(
          u => {
            var user = new AdUser();
            user = u;
            //user.domain = this.getDomainName(u.dn);
            this.users.push(user);
          },
          err => {
            this.errorDialog.showError("AD User Select", err,"","error");
          },
          () => {
            this.pctComplete = Math.floor(++this.itemsComplete / this.totalItems * 100);
            //this.progressDialog.updateProgress(this.pctComplete,"");
            if ( (this.pctComplete >= 100) && (this.domainsSearched == this.domainsTotal) ){
              //this.progressDialog.close();

              //sort user list by domain name, then by userid
              console.log("sorting " + this.users.length + " users.....");
              this.usersSorted = this.users.sort(
                (a,b) =>{
                    if (a.domainName > b.domainName) {return 1};
                    if (a.domainName < b.domainName) {return -1};
                    if (a.domainName.toUpperCase() == b.domainName.toUpperCase()) {
                      if (a.userId > b.userId) {return 1;}
                      if (a.userId < b.userId) {return -1;}
                      return 0; //just in case domain and userid are identical
                    }
                }); //sort

                this.afterLoaded.emit(this.usersSorted);
                this.ldapFilter = '';
            } //if % >= 100
          }); //subscribe
  }


  onUserSelected(user){
    //display adUser details
    this.selectedUser = user;

     var evt = new AdUserSelectedEvent();
     evt.user = user;
     //evt.domain = user.domain;
    this.selectionChange.emit(evt);
  }

  isExpired(user){
    var dt = user.attributes["accountexpires"];
    var expDate = new Date ( dt / 10000 - 11644473600000 );

    var dtNow = new Date(Date.now());

    return expDate < dtNow;
  }
  
  getDomainName(dn:string):string{
    var path = dn.split(',');
    var part = [];
  
    for (var i=0;i<path.length;i++)
    {
        part = path[i].split('=');
        if (part[0].toLowerCase() == 'dc'){
            return part[1].toUpperCase();
        }
    }
    return 'UNKNOWN';
  }
}

export class AdUserSelectedEvent{
  user: AdUser;
  //domain: string;
}

// export class vmUser{
//   adUser: AdUser
//   //domain: string

//   constructor(){
//     this.adUser = new AdUser();
//     //this.domain = '';
//   }

//}