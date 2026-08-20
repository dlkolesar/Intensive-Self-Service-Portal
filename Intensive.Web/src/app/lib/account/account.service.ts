
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material';

import { Observable, from } from 'rxjs';
import { forkJoin } from 'rxjs';

import { mergeMap } from 'rxjs/operators';

import { AccountData } from './account-data';
import { ServerData } from './server-data';
import { ServerService } from './server.service';
import { ApiCollection } from '../shared-data';
import { CachingService } from '../caching';
import { ProgressBarDialog } from '../progress-bar-dialog';
import { ErrorDialog } from '../error-dialog';

import { environment } from '../../../environments/environment';


@Injectable()
export class AccountService {

  account: AccountData;
  itemsComplete:number;
  totalItems: number;
  pctComplete: number;
  private progressDialog: ProgressBarDialog;
  errorDialog: ErrorDialog;


  constructor (private http: HttpClient,
              private cache: CachingService,
              private svrService: ServerService,
              private progDialog: MatDialog,
              private errDialog: MatDialog) {

    this.progressDialog = new ProgressBarDialog(this.progDialog);
    this.errorDialog = new ErrorDialog(this.errDialog);
    this.account = new AccountData();
    this.itemsComplete = 0;
  }

  getAccountData(num): Observable<AccountData> {
    let url = environment.apiCommon + "/accounts/" + num;
    return this.http.get<AccountData>(url);
  }
  
  updateCachedAccount(num: number): Observable<any>{
    this.progressDialog = new ProgressBarDialog(this.progDialog);
    this.errorDialog = new ErrorDialog(this.errDialog);
    this.account = new AccountData();
    this.itemsComplete = 0;
    this.progressDialog.open("Loading Account Data", "determinate");

    return new Observable(o=> {
      forkJoin(this.getAccountData(num),
          this.svrService.getServersForAccount(num),)
      .subscribe( (res:[AccountData, ApiCollection]) =>{
        this.account = new AccountData();
        this.account.number = res[0].number;
        this.account.name = res[0].name;
        this.account.servers = new Array<ServerData>();

        if (res[1].count == 0){ //no servers to load; cache the account data
          this.progressDialog.close();
          this.account.show = true;
          this.cache.account = this.account;
          o.next(this.account);
          o.complete();
        }
        else{
          this.itemsComplete = 0
          this.totalItems = res[1].count;

          // res[1].resources.forEach((url,idx,arr) =>{
          //   this.svrService.getServerByURL(url)
          from(res[1].resources)
            .pipe(
              mergeMap(url => this.svrService.getServerByURL(url),100)
            )
              .subscribe(s => {
                  s.checked = false;
                  s.visible = true;
                  s.statusIcon = '';
                  s.statusIconColor = '';
                  s.statusMessage = '';
                  this.account.servers.push(s);

                  this.itemsComplete++;
                  this.pctComplete = Math.floor(this.itemsComplete / this.totalItems * 100);
                  this.progressDialog.updateProgress(this.pctComplete,"");
                },
                (err) =>{ console.log(err)},
                () => {
                  if (this.pctComplete >= 100) {
                    this.progressDialog.close();
                    this.cache.account = this.account;
                    this.account.show = true;
                    o.next(this.account);
                    o.complete();
                  }
                }//() complete
              ); //subscribe servers
          // });//foreach
        }//else
      },
      err => {
      console.log(err);
      this.progressDialog.close();
      var msg = "Unexpected error lookup up Account and/or server data";
      switch(err.status){
      case 404: msg = "Account " + num + " does not appear to be a valid account number";
      }
      this.errorDialog.open("Account Lookup", 
                          msg,
                          "",
                          "error"
                          )
      });//subscribe
    }); //new Observable
  }
}

