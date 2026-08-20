import { Component, OnInit } from "@angular/core";
import {
  Router,
  ActivatedRoute,
  Params,
  ActivationStart,
  NavigationStart
} from "@angular/router";
import { MatDialog, MatDialogRef, MatDialogConfig } from "@angular/material";
//import { forkJoin } from 'rxjs/observable/forkJoin';

import {
  AccountData,
  AccountService,
  ServerData,
  ServerService
} from "./lib/account";
import { ApiCollection } from './lib/shared-data/api-collection';
import { AppConfigService } from './lib/shared-data/app-config.service';
import { AccountDialog } from "./lib/account/account-dialog/account-dialog.component";
import { AboutComponent } from "./lib/about/about.component";
import { CachingService } from "./lib/caching/caching.service";
import { ProgressBarDialog } from './lib/progress-bar-dialog';
import { ErrorDialog } from './lib/error-dialog';
import { environment } from '../environments/environment';
import { AuthService } from './lib/auth/auth.service';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  account: AccountData;
  acctNum: number;
  accountTitle: string;
  title = environment.siteTitle;
  userIsPatchingAdmin: boolean = false;

  winPatchConfig: Object;

  // private urlSegments;
  // private qsParams;
  // private pctComplete = 0;
  // private itemsComplete = 0;
  // private totalItems = 0;
  // private showTitle: boolean;
  private aboutDialog: MatDialogRef<AboutComponent>;
  private accountDialog: AccountDialog;
  // private progressDialog: ProgressBarDialog;
  // private errorDialog: ErrorDialog;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private auth: AuthService,

    private abtDlg: MatDialog,
    private acctDlg: MatDialog,
    private cache: CachingService,
    private config: AppConfigService
    // private acctService: AccountService,
    // private svrService: ServerService,
    // private progDialog: MatDialog,
    // private errDialog: MatDialog,
  ) {
    console.log("app.component: constructor()");
    // this.progressDialog = new ProgressBarDialog(this.progDialog);
    // this.errorDialog = new ErrorDialog(this.errDialog);
   
    this.account = new AccountData();
    

    this.router.events.subscribe(evt => {
     //  console.log(evt);
    //   //URL params are only available in the ActivationStart event
    //   //However, 2 ActivationStart events are generated due to lazy-module
    //   //loading -- one for the module, and the 2nd for the component
    //   //
    //   //use the event that has the component
    //   //
       if ( (evt instanceof ActivationStart) && (evt.snapshot.component)) {
         this.acctNum = evt.snapshot.params["acct"]; //get the acct number from the URL
       }


      if ( (evt instanceof NavigationStart) && (!evt.url.toLowerCase().includes("/auth")) ) {
          if (environment.production){
            if (this.auth.isAuthenticated()){
              this.winPatchConfig = this.config.getConfig("winpatch");
              var winPatchAdmins = this.winPatchConfig["admins"] as Array<string>;
              this.userIsPatchingAdmin = winPatchAdmins.includes(this.cache.authData.sso);
            }
            else{
              //var baseURL = window.location.protocol + '//' + window.location.hostname;
              var baseURL = 'https://' + window.location.hostname;
              this.auth.redirectToADFS(baseURL + evt.url);
              //this.auth.redirectToADFS(baseURL);
            }
          }
          else{ //dev environment
            if (!this.auth.isAuthenticated()){
              console.log("authData missing from LocalStorage or token has expired");
            }
            this.userIsPatchingAdmin = true;
          }//if env
        }
    });

  }

  ngOnInit() {
    console.log("app.component: ngOnInit()");
    this.cache.Account$.subscribe(a => this.account = a);
    if (this.account.number == 0){
      var r = this.route;
      var rtr = this.router;
    }

   
  }

  //primary menu routing
  routeTo(segments, qs) {
    if (segments.length<=1){
      this.cache.account = null;
      this.acctNum = null;
      this.account.show = false;
    }
    this.router.navigate(segments, qs);
  }
  
  routeToAccount(segments, qs) {
    if (this.acctNum){
      segments[1] = this.acctNum;
      this.router.navigate(segments, qs);
    }else{
      this.accountDialog = new AccountDialog(this.acctDlg);
      this.accountDialog.open();
      this.accountDialog.afterClosed()
        .subscribe(
          a => {
            if (a.toString() != ''){
              this.acctNum = a;
              segments[1] = a; 
              this.router.navigate(segments, qs);
            }
            
          },
          err => {
            // matDialog does not give us an easy way to prevent the 
            // dialog from closing if there is bad/no data entered.
            //
            // This looks recursive, but since it is asynchronouse
            // it works more like a GOTO
            //if (isNaN(a)){ this.routeToAccount(segments, qs)}
            this.routeToAccount(segments, qs)
          }
        )
    }
  }
  openAboutDialog() {
    this.aboutDialog = this.abtDlg.open(AboutComponent);
  }
}
