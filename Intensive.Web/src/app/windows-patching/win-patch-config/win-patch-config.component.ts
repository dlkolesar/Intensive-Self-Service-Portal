import { 
  Component, 
  Directive,
  OnInit,
  ChangeDetectorRef,
  ViewChild,
} from '@angular/core';

import {
  Router,
  ActivatedRoute,
  Params,
  ActivationStart,
  NavigationEnd
} from "@angular/router";

import { NgForm, Validator, ValidatorFn, ValidationErrors, NG_VALIDATORS, AbstractControl, FormGroup } from '@angular/forms';

import { MatDialog, MatDialogRef, MatDialogConfig } from "@angular/material";
import { environment } from '../../../environments/environment';
import {
  AccountData,
  ServerData,
} from "../../lib/account";
import { ApiCollection, AppConfigService } from '../../lib/shared-data';

import { CachingService } from "../../lib/caching/caching.service";
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { TicketDialog } from '../../lib/ticket-dialog/ticket-dialog.component';
import { PatchingAccount, PatchingClient,
         RegistryKeyValue, RegistryKeyValueType, RegistryKey,
         ResetClientIDRegistryKeyValues 
       } from '../models';
import { WinPatchService } from '../win-patch.service';
import {AricService,
        AricProcess,
        PatchNowMetadata, 
        AricTimetable, 
        EventPayload,
        AricDedicatedTarget,
        MetadataRegistryPatching,
        DefaultPatchingRegistryKeys_Pull
      } from '../../aric';
import {AuthData } from '../../lib/auth';

import { Subscription, from } from 'rxjs';
import { interval } from 'rxjs';
import { mergeMap, finalize } from 'rxjs/operators';

import { WinPatchConfigClientComponent } from '../win-patch-config-client/win-patch-config-client.component';

;

@Component({
  selector: 'ss-win-patch-config',
  templateUrl: './win-patch-config.component.html',
  styleUrls: ['./win-patch-config.component.css']
})
export class WinPatchConfigComponent implements OnInit {
  DLG_TITLE = "Windows Patching Configuration";

  account: AccountData;
  patchingAccount: PatchingAccount;
  originalPatchingAccount: PatchingAccount;
  patchNowArguments: PatchNowMetadata = new PatchNowMetadata();

  servers: PatchingClient[];
  selectedClient: PatchingClient;
  originalClient: PatchingClient;
  subStatus: Subscription; //subscription for getting ARIC Job status info

  cfg: object;
  auth: AuthData;

  showForm: boolean = false;
  componentHeight: number = 0;
  progressBarDialog: ProgressBarDialog;
  errorDialog: ErrorDialog;
  ticketDialog: TicketDialog;
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;
  initializing: boolean;

  disablePullButton:boolean = false;
  disablePatchButton: boolean = false;
  disableResetIdButton:boolean = false;
  disableResetSettingsButton: boolean = false;
  disableRefreshButton: boolean = false;

  qsSelected: string[];

  @ViewChild('clientConfig',{static: false}) configComponent: WinPatchConfigClientComponent;

  constructor(private router: Router, 
              private route: ActivatedRoute,
              private cache: CachingService,
              private patching: WinPatchService,
              private chgs: ChangeDetectorRef,
              private aric: AricService,
              private config: AppConfigService,
              private dlgTicket: MatDialog,
              private dlgProgressBar: MatDialog,
              private dlgError: MatDialog) { 
    
    console.log("win-patch.component: constructor()");
    this.router.events.subscribe(evt => {
      console.warn(evt);
    });
    
    this.route.queryParams.subscribe((p: Params) => {
      if (p["select"]){
        this.qsSelected = p["select"].split(',');
      }
      else{
        this.qsSelected = [];
      }
    });

    this.componentHeight = window.innerHeight - 85;
    this.selectedClient = new ServerData(0,'Click on a server from the list to display its configuration') as PatchingClient;

    this.progressBarDialog = new ProgressBarDialog(this.dlgProgressBar);
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.ticketDialog = new TicketDialog(this.dlgTicket);

    this.cache.showAccount(); //show the account in the banner

    this.cfg = this.config.getConfig("winpatch");
    this.auth = this.cache.authData;
  }

  ngOnInit() {
    console.log("win-patch.component: OnInit()");
    this.account = this.cache.account;
    //this.servers = this.account.servers.filter(s => s.wsusid != null && s.wsusid != '00000000-0000-0000-0000-000000000000') as PatchingClient[];
    this.servers = this.account.servers as PatchingClient[];
    this.initializing = true;
    this.GetPatchingAccount();
  }

  accountChange(e){
    if (e.accountOptOut != undefined){
      //show ticket dialog
      this.ticketDialog.open();

    
      this.ticketDialog.afterClosed()
          .subscribe(
            tkt => {
              if (tkt == ''){ //cancelled button
                //flip back to the original value
                this.patchingAccount.optedOut = !this.patchingAccount.optedOut; 
              }
              else{
                this.AccountOptInOut(tkt);
              }
              
            }
          );//subscribe

      
    }

    // if (e.ticketingOptOut){
    //   if (e.ticketingOptOut){
    //     //this.patchingAccount.optedOutOfTicketing = e.ticketingOptOut;
    //     //opt out of patching tickets
    //   }
    //   else{
    //     //opt out of patching tickets
    //   }
    // }
  }


  AccountOptInOut(tkt:string){
    this.progressBarDialog.open("Account Opt-In/Opt-Out","indeterminate");
    var msg = (this.patchingAccount.optedOut)? "Opting Account OUT.....": "Opting Account IN.....";
    this.progressBarDialog.updateProgress(-1,msg);

    this.patching.AccountOptInOut(this.patchingAccount.number, this.patchingAccount.optedOut, tkt)
          .subscribe(
            res => {
              this.progressBarDialog.close();
              if (!this.patchingAccount.optedOut){ //i.e.is the account being opted IN?
                // this.errorDialog.open("Account Opted In",
                //                 "The account servers and their patch settings are being loaded in the background. Refresh the page to see new servers. Once the settings have been pulled for all discovered devices, reload the page one more time to refresh/reset any error messages.  For large accounts, this can take several minutes.",
                //                 "",
                //                 "info"
                //                );
                  //split account resolver into a callable service and resolver that calls that service
                  //that enables the service to be called from here to "reload/resolve" the account automagically after opt in
                  this.RefreshAccount();
              }
              
            },
            err => {
              this.progressBarDialog.close();
              this.errorDialog.showError("Account Opt-In/Opt-Out",err,"","error");
            }
          );
                
          
  }


  GetPatchingAccount(){
    this.progressBarDialog.open("Loading Patching Account data", "indeterminate" );

    this.patching.getPatchingAccount(this.account.number)
          .subscribe( pa => {
           // this.progressBarDialog.close();
            this.patchingAccount = pa;
            this.originalPatchingAccount = JSON.parse(JSON.stringify(this.patchingAccount));

            this.disableRefreshButton = this.patchingAccount.optedOut;  //if opted out, disable the Refresh button

            if ((!this.patchingAccount.optedOut)&&(this.servers.length>0) ){
              this.GetPatchingClients();
            }
            else{
              this.progressBarDialog.close();
              this.showForm = true;
            }
          },
          err => {
            console.log("apierror: " + err);
            this.progressBarDialog.close();
            this.disableRefreshButton = true;

            if (err.status == 404){ //account not found in patchingAccounts table
              this.patchingAccount = new PatchingAccount();
              this.patchingAccount = this.account as PatchingAccount;
              this.patchingAccount.optedOut = true;
              this.patchingAccount.servers= new Array<PatchingClient>();
              this.showForm = true;
            }
            else{
              this.errorDialog.open("Patching Account", err.message,"","error");
            }
          });
  }

  // GetPatchingClients(){
  //   this.progressBarDialog.open("Loading Patching Client data", "determinate" );
  //   this.itemsComplete = 0;
  //   this.totalItems = this.servers.length;
  //   this.servers.forEach( (svr, idx, arr) =>{
  //     this.GetPatchingClient(svr.deviceNumber);
  //   });
  //   //this.refreshJobStatus();
  // }
  
  // GetPatchingClient(num){
  //   this.patching.getPatchingClient(num)
  //         .subscribe( pc => {
  //               let index = this.servers.findIndex(d => d.deviceNumber === pc.deviceNumber);
  //               var chkd = this.servers[index].checked; //save checked state

  //               this.servers[index].osVersion = pc.osVersion;
  //               this.servers[index].osMajorVersion = pc.osMajorVersion;
  //               this.servers[index].osMinorVersion = pc.osMinorVersion;
  //               this.servers[index].osBuildNumber = pc.osBuildNumber;
  //               this.servers[index].unSupportedOS = pc.unSupportedOS;
  //               this.servers[index].targetId = pc.targetId;
  //               this.servers[index].patchingLevel = pc.patchingLevel;
  //               this.servers[index].useWUServer= pc.useWUServer;
  //               this.servers[index].wuServer = pc.wuServer; 
  //               this.servers[index].wuStatusServer = pc.wuStatusServer;
  //               this.servers[index].noAutoUpdate = pc.noAutoUpdate;
  //               this.servers[index].auOptions = pc.auOptions;
  //               this.servers[index].optedOut = pc.optedOut;
  //               this.servers[index].rebootPending = pc.rebootPending;
  //               this.servers[index].lastPatchDate = pc.lastPatchDate;
  //               this.servers[index].nextPatchDate = pc.nextPatchDate;
  //               this.servers[index].lastContact = pc.lastContact;
  //               this.servers[index].errors = pc.errors;
  //               this.servers[index].noAutoRebootWithLoggedOnUsers = pc.noAutoRebootWithLoggedOnUsers;
  //               this.servers[index].scheduledWeek = pc.scheduledWeek;
  //               this.servers[index].scheduledDay = pc.scheduledDay;
  //               this.servers[index].scheduledTime = pc.scheduledTime
  //               this.servers[index].advancedPatching = pc.advancedPatching;

  //               this.servers[index].checked = chkd;   //restore checked state
                
  //               this.setStatus(this.servers[index], '','');

  //               // if (pc.errors.length>0){
  //               //   //this.servers[index].statusMessage = pc.errors.join('\r\n');
  //               //   //this.servers[index].statusIcon = "warning"; 
  //               //   //this.servers[index].statusIconColor = "orange";
  //               //   this.setStatus(this.servers[index], '',pc.errors.join('\r\n'));
  //               // }

  //               // if (pc.optedOut){
  //               //   // this.servers[index].statusIcon = "cancel"; 
  //               //   // this.servers[index].statusIconColor = "darkred";
  //               //   // this.servers[index].statusMessage = "This server has been OPTED OUT ";
  //               //   this.setStatus(this.servers[index], 'optedout','This server has been OPTED OUT');
  //               // }

  //               if (this.qsSelected.indexOf(pc.deviceNumber.toString()) > -1 )
  //               {
  //                 this.servers[index].checked = true;
  //                 if (this.selectedClient.deviceNumber == 0){
  //                   this.serverClick(pc); 
  //                 }
  //               }
  //             },
  //             err => {
  //               console.log("apierror: " + err)
  //             },
  //             () => {
  //               this.itemsComplete++;
  //               this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
  //               this.progressBarDialog.updateProgress(this.pctComplete,"");
  //               if (this.pctComplete >= 100) {
  //                 this.servers.sort( //sort the server list
  //                   (a,b) =>{
  //                     if (a.name > b.name) {return 1;}
  //                     if (a.name < b.name) {return -1;}
  //                     return 0;
  //                   }
  //                 );
  //                 this.disablePullButton = true;
  //                 this.disablePatchButton = true;
  //                 this.disableResetIdButton = true;
  //                 this.disableResetSettingsButton = true;
    
  //                 this.showForm = true;
  //                 this.progressBarDialog.close();
                  
  //                 this.refreshJobStatus();
  //               }
  //         })
  // }


  GetPatchingClients(){
    this.progressBarDialog.open("Loading Patching Client data", "determinate" );
    this.itemsComplete = 0;
    this.totalItems = this.servers.length;
    
    from(this.servers)
      .pipe(
        mergeMap(s => this.patching.getPatchingClient(s.deviceNumber), 100)
      )
      .subscribe( pc => {
        let index = this.servers.findIndex(d => d.deviceNumber === pc.deviceNumber);
        var chkd = this.servers[index].checked; //save checked state

        this.servers[index].osVersion = pc.osVersion;
        this.servers[index].osMajorVersion = pc.osMajorVersion;
        this.servers[index].osMinorVersion = pc.osMinorVersion;
        this.servers[index].osBuildNumber = pc.osBuildNumber;
        this.servers[index].unSupportedOS = pc.unSupportedOS;
        this.servers[index].targetId = pc.targetId;
        this.servers[index].patchingLevel = pc.patchingLevel;
        this.servers[index].useWUServer= pc.useWUServer;
        this.servers[index].wuServer = pc.wuServer; 
        this.servers[index].wuStatusServer = pc.wuStatusServer;
        this.servers[index].noAutoUpdate = pc.noAutoUpdate;
        this.servers[index].auOptions = pc.auOptions;
        this.servers[index].optedOut = pc.optedOut;
        this.servers[index].rebootPending = pc.rebootPending;
        this.servers[index].lastPatchDate = pc.lastPatchDate;
        this.servers[index].nextPatchDate = pc.nextPatchDate;
        this.servers[index].lastContact = pc.lastContact;
        this.servers[index].errors = pc.errors;
        this.servers[index].noAutoRebootWithLoggedOnUsers = pc.noAutoRebootWithLoggedOnUsers;
        this.servers[index].scheduledWeek = pc.scheduledWeek;
        this.servers[index].scheduledDay = pc.scheduledDay;
        this.servers[index].scheduledTime = pc.scheduledTime
        this.servers[index].advancedPatching = pc.advancedPatching;

        this.servers[index].checked = chkd;   //restore checked state
        
        this.setStatus(this.servers[index], '','');

        if (this.qsSelected.indexOf(pc.deviceNumber.toString()) > -1 )
        {
          this.servers[index].checked = true;
          if (this.selectedClient.deviceNumber == 0){
            this.serverClick(pc); 
          }
        }

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
          this.servers.sort( //sort the server list
            (a,b) =>{
              if (a.name > b.name) {return 1;}
              if (a.name < b.name) {return -1;}
              return 0;
            }
          );
          this.disablePullButton = true;
          this.disablePatchButton = true;
          this.disableResetIdButton = true;
          this.disableResetSettingsButton = true;

          this.showForm = true;
          this.progressBarDialog.close();
          
          this.refreshJobStatus();
        }
      })//subscribe
  }


  serverClick(svr){
    //this.selectedClient = svr;
    let index = this.servers.findIndex(d => d.deviceNumber === svr.deviceNumber);
    this.selectedClient = this.servers[index];

    this.originalClient = JSON.parse(JSON.stringify(this.selectedClient));

    if ( (this.selectedClient.patchingLevel == 1) && (this.selectedClient.auOptions!= 4) && (this.selectedClient.auOptions !=5) ){
      this.selectedClient.auOptions = this.cfg["defaultAUOptions"] as number;
      //if (this.selectedClient.scheduledDay )//null, -1 , undefined????
    }
     
    if ( (this.selectedClient.patchingLevel == 3) && (this.selectedClient.auOptions!= 2) && (this.selectedClient.auOptions !=3) )
    {
      this.selectedClient.auOptions = 3; //default to download and install
    }

    this.disablePullButton = false;
    this.disablePatchButton = false;
    this.disableResetIdButton = false;
    this.disableResetSettingsButton = false;
    
    

    
    if (this.selectedClient.optedOut){
      this.disablePullButton = true;
      this.disablePatchButton = true;
      this.disableResetIdButton = true;
      this.disableResetSettingsButton = true;
    }
    else{
      if (this.selectedClient.patchingLevel == 0){
        this.disablePullButton = true;
        this.disablePatchButton = true;
        this.disableResetIdButton = true;
        this.disableResetSettingsButton = true;
      }
    }
  }
  
  checkboxChange(svr){
    if (this.selectedClient.deviceNumber == 0){
      this.serverClick(svr); 
    }
  }

  standardServerName(name:string){
    return (name.match(/^\d*\-.*/));
  }

//button handlers

  RefreshAccount(){
    console.log("Reloading account....");
    this.progressBarDialog.open("Refreshing Server List", "indeterminate");

    this.patching.AccountRefresh(this.account.number)
      .subscribe(
        api  => {
          this.progressBarDialog.close();
          if (api.count > 0){
            this.errorDialog.open("Refreshing Server List",
              api.count + ' new servers found. Settings are being pulled on each new server',
              "",
              "info"
            );
            this.RefreshComputers(api);
          }
          else{
            this.errorDialog.open("Refreshing Server List",
              'No new servers were discovered',
              "",
              "info"
            );
          }
        },
        err => {}
      );
  } 

  RefreshComputers(api: ApiCollection){
    //clear all checkboxes, since we are going to mark "discovered"
    //servers with a check
    this.servers.forEach( s => s.checked = false);

    //this.progressBarDialog.updateProgress(-1,'Discovered ' + api.count + ' new servers');
    from(api.resources) //foreach url in the resources array
      .pipe(
        mergeMap( url => this.patching.getPatchingClientResource(url))  //execute GetObjectURL
      )
      .pipe(finalize(
        ()=> {
            // all servers have been added to cached account.servers
            this.cache.account = this.account;

            // now trigger this.GetPatchingAccount() to reload everything
            console.log("finished.  Calling GetPatchingAccount()....");
            //this.initializing = true;
            // this.servers.sort( //sort the server list
            //   (a,b) =>{
            //     if (a.name > b.name) {return 1;}
            //     if (a.name < b.name) {return -1;}
            //     return 0;
            //   }
            // );
            this.progressBarDialog.close();
            // this.errorDialog.open("Refreshing Server List",
            //   'Pulling Settings for ' + api.count + ' newly discovered servers. New servers will have their checkbox checked.',
            //   "",
            //   "info"
            // );
            this.PullSettingsNow();// for all checked servers

            this.servers = this.account.servers as PatchingClient[];
            this.GetPatchingAccount();
          }
        )
      )
        .subscribe(
          s => { //patchingClient
            //add to cached account.servers
            console.log('new server detected(' + s.name + '). adding to cached account')
            let d = new ServerData(s.deviceNumber,s.name);
            d.checked = true;
            this.account.servers.push(d);
            
            // s.checked = true;
            // this.servers.push(s);
            //this.servers = this.account.servers as PatchingClient[];

          },
          error => {
            this.progressBarDialog.close();
            console.log(error);
            this.errorDialog.openApiError("Reloading Account",error);
          }
        );
    
  }

  PullSettingsNow(){
    let selectedServers = this.servers.filter( function(svr, indx, arr){
      return ( svr.checked && !svr.optedOut); //svr is checked and is opted IN
    });

    this.totalItems = selectedServers.length;
    this.itemsComplete = 0;

    this.progressBarDialog.open("Pulling Settings", "discriminate");
    this.progressBarDialog.updateProgress(0, "Pulling Settings on selected clients....");
    selectedServers.forEach(
      (svr, indx,arr) => {
        this.pullSettingsFromClient(svr);
        this.setStatus(svr, "busy", "Submitting job to ARIC...");
    });
  }

 
  pullSettingsFromClient(svr: PatchingClient){
    this.patching.performPatchingClientAction(svr, "pullsettings")
      .subscribe(
        e => {
          console.log(e);
        },
        err =>{
          console.log(err);
          this.progressBarDialog.close();
          this.errorDialog.showError("Pulling Settings", err, '', "error")
        },
        () => {
          this.itemsComplete++;
          this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
          this.progressBarDialog.updateProgress(this.pctComplete,"");
          if (this.pctComplete >= 100) {
            this.showForm = true;
            this.progressBarDialog.close();
            this.refreshJobStatus();
          }
        }
      );//subscribe
  }

  PatchNow(){
    let selectedServers = this.servers.filter( function(svr, indx, arr){
      return ( svr.checked && !svr.optedOut); //svr is checked and is opted IN
    });

    this.totalItems = selectedServers.length;
    this.itemsComplete = 0;

    this.progressBarDialog.open("Patch Now", "discriminate");
    this.progressBarDialog.updateProgress(0, "Patching selected clients....");
    selectedServers.forEach(
      (svr, indx,arr) => {
        this.patchServer(svr);
        this.setStatus(svr, "busy", "Submitting job to ARIC...");
    });
    //this.refreshJobStatus(); //start auto-refresh loop for job status 
  }

 patchServer(svr: PatchingClient){
    this.patching.performPatchingClientAction(svr, "patchnow")
      .subscribe(
        e => {
          console.log(e);
        },
        err =>{
          console.log(err);
          this.progressBarDialog.close();
          this.errorDialog.showError("Patch Now", err, '', "error")
        },
        () => {
          this.itemsComplete++;
          this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
          this.progressBarDialog.updateProgress(this.pctComplete,"");
          if (this.pctComplete >= 100) {
            this.showForm = true;
            this.progressBarDialog.close();
            this.refreshJobStatus();
          }
        }
      );//subscribe
  }

  ResetClientId(){  
    // reset the client id
    let selectedServers = this.servers.filter( function(svr, indx, arr){
      return ( svr.checked && !svr.optedOut); //svr is checked and is opted IN
    });

    this.totalItems = selectedServers.length;
    this.itemsComplete = 0;

    this.progressBarDialog.open("Reset WSUS ID", "discriminate");
    this.progressBarDialog.updateProgress(0, "Resetting selected clients....");

    if (this.selectedClient.deviceNumber == 0){//device has not been clicked on
      this.serverClick(selectedServers[0]); //"click" the first checked servers
    }

    selectedServers.forEach(
      (svr, indx,arr) => {
        this.resetId(svr);
        this.setStatus(svr, "busy", "Submitting job to ARIC...");
        // if (indx >= arr.length - 1){ //if we have reset the last one
        //   this.PullSettingsNow(); //"click" the Pull Settings Now button for the user
        // }
    });
  }

  resetId(svr: PatchingClient){
    this.patching.performPatchingClientAction(svr, "resetwsusid")
      .subscribe(
        e => {
          console.log(e);
        },
        err =>{
          console.log(err);
          this.progressBarDialog.close();
          this.errorDialog.showError("Reset WSUS ID", err, '', "error")
        },
        () => {
          this.itemsComplete++;
          this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
          this.progressBarDialog.updateProgress(this.pctComplete,"");
          if (this.pctComplete >= 100) {
            this.showForm = true;
            this.progressBarDialog.close();
            this.refreshJobStatus();
            this.errorDialog.open("Reset WSUS ID", 'Reset WSUS Client id job(s) have been submitted.  After all jobs are complete, you should Pull Settings to update the WSUS ID in the database', '', "warning")
          }
        }
      );//subscribe
  }

  

  onResetSettings(){
    let selectedServers = this.servers.filter( function(svr, indx, arr){
      return ( svr.checked && !svr.optedOut); //svr is checked and is opted IN
    });

    this.totalItems = selectedServers.length;
    this.itemsComplete = 0;

    this.progressBarDialog.open("Revert to Rackspace Defaults", "discriminate");
    this.progressBarDialog.updateProgress(0, "Setting Rackspace default values on selected clients....");
    selectedServers.forEach(
      (svr, indx,arr) => {
        this.resetSettingsRS(svr);
        this.setStatus(svr, "busy", "Submitting job to ARIC...");
    });
  }
  
  resetSettingsRS(svr: PatchingClient){
    this.patching.performPatchingClientAction(svr, "defaulttors")
      .subscribe(
        e => {
          console.log(e);
        },
        err =>{
          console.log(err);
          this.progressBarDialog.close();
          this.errorDialog.showError("Revert to Rackspace Defaults", err, '', "error")
        },
        () => {
          this.itemsComplete++;
          this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
          this.progressBarDialog.updateProgress(this.pctComplete,"");
          if (this.pctComplete >= 100) {
            this.showForm = true;
            this.progressBarDialog.close();
            this.refreshJobStatus();
          }
        }
      );//subscribe
  }


  onSubmit(frmData:NgForm) {
    this.SaveAccountData();

    if (this.ValidData(frmData)){ 
      if (!this.patchingAccount.optedOut){  //only save client config data if the account is opted IN
        this.SaveClientData(); 
      }
    }
    else{
      this.errorDialog.open(this.DLG_TITLE,
                    "One or more fields are empty or have invalid data. Check all tabs for red highlighted fields",
                    "",
                    "error"
                  );
    }
  }

  SaveAccountData(){
    //was the optedOutOfTicketing value changed?
    //if (this.patchingAccount.optedOutOfTicketing != this.originalPatchingAccount.optedOutOfTicketing){
      this.progressBarDialog.open(this.DLG_TITLE,"indeterminate");
      this.patching.savePatchingAccount((this.patchingAccount))
      .pipe(finalize(
              () => {
                this.progressBarDialog.close();
              }
            ))
            .subscribe(
              a => { 
              },
              error => {
                if (error.status != '304'){ //nothing changed
                  this.errorDialog.showError(this.DLG_TITLE, error, "", "error");
                }
              },
            );
   // }
    
  }

//end button handlers


SaveClientData(){
  this.pctComplete = 0;
  var completed = 0;

  var changes = this.FindChanges();
  

  if (Object.keys(changes).length == 0){
    this.errorDialog.open(this.DLG_TITLE,
                    "You haven't changed anything; nothing to save",
                    "",
                    "warning"
                  );
    return true;
  }

   //get all servers that have been "checked" but not opted out
   //if the "optedout" property is being changed, then select that server 
   let selectedServers = this.servers.filter( function(svr, indx, arr){
      if (svr.checked){
        if (changes["optedOut"]){ //server is being opted IN or OUT
          return true;
        }
        else{
          return !svr.optedOut
        }
      } //if checked
    });
  
  if (selectedServers.length == 0){
      this.errorDialog.open(this.DLG_TITLE,
                      "No servers are selected or all selected servers have been opted out.\r\n Make sure at least one server is checked",
                      "",
                      "warning"
                    );
      return false;
  }
  

  if (selectedServers.length > 0){
    this.progressBarDialog.open(this.DLG_TITLE,"determinate");
    this.progressBarDialog.updateProgress(this.pctComplete,"" );
  }


  for(var i=0;i<selectedServers.length;i++)
  {
    let svr = selectedServers[i];
    
    //assign changed values to the selected server
    console.log('svr b4 changes: ' + JSON.stringify(svr));
    for (var k of Object.keys(changes)){
      if (k == "advancedPatching") {
        //svr.patchingLevel = 2;  //force patching level to Advanced, since we are setting an advanced patching property
        
        if (svr.advancedPatching == null){                      //if no adv patching property
          svr.advancedPatching = this.selectedClient.advancedPatching;  //init from current client
          svr.advancedPatching.id = "00000000-0000-0000-0000-000000000000"; //reset the id, to force an ADD/CREATE
        }                                                      

        //apply adv patching property changes
        for (var p of Object.keys(changes["advancedPatching"])){
          //apply adv patching argument changes
          if (p == "arguments"){
            for (var a of Object.keys(changes["advancedPatching"]["arguments"])){
              svr.advancedPatching.arguments[a]= changes["advancedPatching"]["arguments"][a];
            }
          }
          else{
            svr.advancedPatching[p] = changes["advancedPatching"][p];
          }
        }

        svr.advancedPatching.monthOfYear = "*";
      }
      else{
        svr[k] = changes[k];
      }
    } //for Object.keys(changes)
    
    console.log('svr after changes: ' + JSON.stringify(svr));

    let n = this.servers.findIndex(d => d.deviceNumber == svr.deviceNumber);
    this.servers[n].errors = new Array();

    this.setStatus(this.servers[n], "busy", "Saving to changes to the database....");
      
    this.patching.savePatchingClient(svr)
    .pipe(finalize(
            () => {
              this.pctComplete = Math.floor((++completed/selectedServers.length)*100);
              this.progressBarDialog.updateProgress(this.pctComplete,"");
              if (this.pctComplete >= 100){
                this.progressBarDialog.close();
                this.originalClient = JSON.parse(JSON.stringify(this.selectedClient)); //reset originalClient so we can detect the next set of changes

                this.refreshJobStatus();//start job refresh loop
              }
            })
          )
          .subscribe(
            d => { 
              n = this.servers.findIndex(svr => svr.deviceNumber == d.deviceNumber);
              this.servers[n].errors = new Array();

              //copy the visible & checked properties from the original client
              d.visible = this.servers[n].visible;
              d.checked = this.servers[n].checked;
              
              this.servers[n] = d;  //replace the original client with the new, updated client

              if (this.servers[n].optedOut){
                this.setStatus(this.servers[n],"optedout", "Client has been opted out"); //clear status
              }
              else{
                //this.pushSettingsToClient(this.account.number, this.servers[n], changes);
              }
            },
            error => {
              // if error.status
              //
              var urlParts = error.url.split('/');
              var device = +urlParts[urlParts.length - 1];
              n = this.servers.findIndex(d => d.deviceNumber == device);

              if (error.status == 0){
                //this.ShowError("Saving Client Config", "unable to connect to API server","", "error");
                this.setStatus(this.servers[n], "error", "Unable to connect to API server");
              }
              else{
                this.setStatus(this.servers[n], "error", error._body);
              }
            });
          // ARIC service push registry changes
  }//for
}


ValidData(frm:NgForm){
  var ok = true;
  // if ( ( (frm.controls.patchingLevel.value == 1) && (frm.controls.auOptions.value!= 4) && (frm.controls.auOptions.value !=5) )
  //   || ( (frm.controls.patchingLevel.value == 3) && (frm.controls.auOptions.value!= 2) && (frm.controls.auOptions.value !=3) )
  //   ){
  //         frm.controls.auOptions.setErrors({"optionMismatch": true})
  //         ok = false;
  // }

  // if ( (frm.controls.patchingLevel.value == 1) || (frm.controls.patchingLevel.value == 3) ) { //validate schedule data if Patching Level is Basic or Manual
  //   if ( (frm.controls.scheduledWeek.value < 0) || (frm.controls.scheduledWeek.value > 3) ){
  //     frm.controls.scheduledWeek.setErrors({"required": true})
  //     ok = false;
  //   }
  //   if ( (frm.controls.scheduledDay.value < 0) || (frm.controls.scheduledDay.value > 7) ){
  //     frm.controls.scheduledDay.setErrors({"required": true})
  //     ok = false;
  //   }
  //   if ( (frm.controls.scheduledTime.value < 0) || (frm.controls.scheduledTime.value > 23) ){
  //     frm.controls.scheduledTime.setErrors({"required": true})
  //     ok = false;
  //   }
  // }

  // if (frm.controls.patchingLevel.value == 2) { //validate adv schedule data if Patching Level is Advanced
  //   console.log("adv week: '" + frm.controls.advSchTime.value + "'");
  //   if (frm.controls.advSchWeek.value == '') {
  //     frm.controls.advSchWeek.setErrors({"required": true});
  //     ok = false;
  //   }
  //   if (frm.controls.advSchDay.value == '') {
  //     frm.controls.advSchDay.setErrors({"required": true})
  //     ok = false;
  //   }
  //   if (frm.controls.advSchTime.value == '') {
  //     frm.controls.advSchTime.setErrors({"required": true})
  //     ok = false;
  //   }
  //}




  return ok;
}

FindChanges():Object{
  var chgs = new Object();
  var v1, v2;
  var properties = [
    'wsusid',
    'useWUServer',
    'wuServer',
    'patchingLevel',
    'noAutoUpdate',
    'auOptions',
    'optedOut',
    'noAutoRebootWithLoggedOnUsers',
    'scheduledWeek',
    'scheduledDay',
    'scheduledTime',
    'advancedPatching',
  ];

  for (var property of properties) {
    if (property == 'advancedPatching'){
      if (this.selectedClient.patchingLevel == 2){            //is the current patching level = advanced?
        if (this.originalClient.patchingLevel == 2){  //was it advanced previously?
          //patching level is advanced and has not been changed 
          //check to see if any advanced properties have changed
          var advProperties = [
            //'id',
            'processName',
            'minute',
            'hour',
            'dayOfWeek',
            'dayOfMonth'
          ];
          for (var p of advProperties) { //compare each Advance Patching property to the original
            if (this.selectedClient.advancedPatching[p] != this.originalClient.advancedPatching[p]){
              if (!chgs["advancedPatching"]) { chgs["advancedPatching"] = new Object(); }
              chgs['advancedPatching'][p] = this.selectedClient['advancedPatching'][p];
            }
          }

          //check if any Adv Patching arguments have changed
          var advArguments = [
            //'id',
            'endtime',
            'downloadPatches',
            'installPatches',
            'reboot',
            'forceReboot'
          ];

          for (var a of advArguments) { //compare each Advance Patching Argument to the original
            if (this.selectedClient.advancedPatching.arguments[a] != this.originalClient.advancedPatching.arguments[a]){
              if (!chgs["advancedPatching"]) { chgs["advancedPatching"] = new Object(); }
              if (!chgs["advancedPatching"]["arguments"]) { chgs["advancedPatching"]["arguments"] = new Object(); }
                chgs['advancedPatching']["arguments"][a] = this.selectedClient.advancedPatching.arguments[a];
            }
          }
         
        }
        else{ 
          //patching level is being changed to Advanced
          // copy all adv patching properties
          chgs['advancedPatching'] = this.selectedClient.advancedPatching;
        }
      }
    }
    else{
      if (this.selectedClient[property] != this.originalClient[property]){
        chgs[property] = this.selectedClient[property];
      }
    }
  }

  return chgs;
}





// ARIC Job status
refreshJobStatus(){
  var seconds = 10;
  if ( (!this.subStatus) || (this.subStatus.closed) ){ //if status refresh is not already running
    this.updateJobStatus();//update statuses immediately before waiting 10 seconds for the next
    console.log("starting refresh loop");
    this.subStatus = interval(seconds * 1000)
                      .subscribe( t => {
                        console.log("refreshing....");
                        this.updateJobStatus();
                      });
  } //if
}

stopRefreshLoop(){
  if (this.subStatus)
  {
    console.log("killing refresh loop");
    this.subStatus.unsubscribe(); //kill the refresh loop
  }
}

updateJobStatus(){
  //reset job status for each opted in server
  this.servers.forEach( (svr, idx, arr) => {
    this.setStatus(svr, "", "");
  });

  // find all the Patching jobs for this account
    this.aric.findJobs(this.cfg["systemId"], this.account.number)
      .subscribe( jobs => {
        if (jobs.count == 0) {
          this.stopRefreshLoop();
          if (this.initializing){
            this.initializing = false;
          }
          else{
            this.UpdateSelectedServerData(); 
          }
        }
        else{
          this.updateJobDeviceStatus(jobs.resources);
        }
      },
      err => {
        console.log(err);
        this.stopRefreshLoop();
      });//subscribe
}

updateJobDeviceStatus(urls: string[]){
  let processesStillRunning: number = 0;
  let counter: number = 0;

  urls.forEach( (url,idx,arr) => {
    this.aric.getJobByURL(url)
    .pipe(finalize( ()=>{
          ++counter;
          //console.log("[finally] counter=" + counter + "   running=" + processesStillRunning);
          if (counter >= urls.length) { //all jobs have been checked
            if (processesStillRunning == 0){
              this.stopRefreshLoop();
              //just in case the job altered any server config data; 
              //re-fetch the data from the db
              if (this.initializing){
                this.initializing = false;
              }
              else{
                this.UpdateSelectedServerData(); 
              }
            }
          }
      })
    )
      .subscribe( job => {
          var i = this.servers.findIndex(s=> s.deviceNumber == job.deviceNumber)
          //var svr =  this.servers[i];
          // if (i == -1){
          //   let pc = new PatchingClient(job.deviceNumber, "retrieving....");
          //   i = this.servers.push(pc) - 1; //set the index number
          //   this.account.servers = this.servers as ServerData[]; //update the account server cache
          //   this.cache.account = this.account;
          // }
        if (i > -1){
          switch (job.state.toLowerCase())
          {
            case "pending":  {
                  this.setStatus(this.servers[i], "busy", "Waiting for ARIC to run process " + job.processName + " on this server");
                  //this.setStatus(svr, "busy", "Waiting for ARIC to run process " + job.processName + " on this server");
                  processesStillRunning++;
                  break;
            }
            case "running":  {
                this.setStatus(this.servers[i], "busy", job.processName + ": " +job.message);
                //this.setStatus(svr, "busy", job.processName + ": " +job.message);
                processesStillRunning++;
                break;
            }
            case "failed":  {
                this.setStatus(this.servers[i], "error", job.processName + ": " + job.returnedData);
                //this.setStatus(svr, "error", job.processName + ": " + job.returnedData);
                break;
            }
          }//switch
        }//if i < -1
      },
      err => {
      });//subscribe
  });//foreach
} 

setStatus(svr: PatchingClient, status: string, msg: string){
  //if status="" then set the status icon based on the current state of the server
  svr.statusMessage = '';
  if (status == ""){
    if (svr.errors.length > 0){
      status = "error"; 
      svr.statusMessage = svr.errors.join('\r\n');
    }
  }
    //opted-out status overrides any errors
    if (svr.optedOut){
      svr.errors = [];
      status = "optedout";
      svr.statusMessage = "This client has been opted OUT"
    }
  //}

  switch (status.toLocaleLowerCase()){
    case "": { svr.statusIcon = ""; svr.statusIconColor = ""; break; }
    case "ok": { svr.statusIcon = "check_circle"; svr.statusIconColor = "darkgreen"; break; }
    case "optedout": { svr.statusIcon = "cancel"; svr.statusIconColor = "darkred"; break;}
    case "busy": { svr.statusIcon = "cached"; svr.statusIconColor = "blue";  break;}
    case "warning": { svr.statusIcon = "warning"; svr.statusIconColor = "orange";  break;}
    case "error": { svr.statusIcon = "error"; svr.statusIconColor = "darkred";  break;}
  }

  if (msg != '') {
    svr.statusMessage += '\r\n' + msg;
  }
}


UpdateSelectedServerData(){
  let selectedServers = this.servers.filter( function(svr, indx, arr){
    return ( svr.checked && !svr.optedOut); //svr is checked and is opted IN
  });

  if (selectedServers.length > 0){
    this.progressBarDialog.open("Refreshing Selected Data", "determinate");
    this.itemsComplete = 0;
    this.totalItems = selectedServers.length;

    selectedServers.forEach(
      (svr, indx,arr) => {
        console.log("updating server data for device " + svr.deviceNumber);
        //this.totalItems = Infinity;
        //this.GetPatchingClient(svr.deviceNumber);

        this.patching.getPatchingClient(svr.deviceNumber)
          .subscribe(
            d => { 
              var i = this.servers.findIndex(s=> s.deviceNumber == d.deviceNumber)

              //trigger angular's detection mechanism by
              //mutating the "servers" array rather than
              //just mutating the data at servers[i]
              this.setStatus(d,'','');
              d.checked = this.servers[i].checked;
              d.visible = this.servers[i].visible;
              var s = [...this.servers];
              s[i] = d;
              this.servers = [...s];

              if (this.selectedClient.deviceNumber == d.deviceNumber){
                this.serverClick(d);//simulate a click to reload/redisplay the updated data
              }
                this.itemsComplete++;
                this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
                this.progressBarDialog.updateProgress(this.pctComplete, svr.name);
                if (this.pctComplete >= 100){
                  this.progressBarDialog.close();
                }
            },
            err =>{
              console.log(err);
              this.itemsComplete++;
              if (this.itemsComplete >= this.totalItems){
                this.progressBarDialog.close();
              }
            }); //subscribe
      });
  }//if selectedServers > 0
}

}

