import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';
import { Injectable }             from '@angular/core';
import { Observable, from }             from 'rxjs';
import { forkJoin } from 'rxjs';
//import { _finally } from 'rxjs/operator/finally';

import { mergeMap } from 'rxjs/operators';

import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { MatDialog } from '@angular/material';

import { AccountData } from './account-data';
import { AccountService } from './account.service';

import { CachingService } from '../caching';


@Injectable()
export class AccountResolverService implements Resolve<AccountData>{

  account: AccountData;
  itemsComplete:number;
  totalItems: number;
  pctComplete: number;

  acctObs: Observable<AccountData>; 
  constructor(
              private cache: CachingService,
              private acctService: AccountService) { 

  this.account = new AccountData();
}
            

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<AccountData> {
    let num = route.params.acct;
    console.log("Resolving Account " + num);
    this.account = null;

    return new Observable<AccountData>(o=> {
        // check cache first
        if ( (this.cache.account) && (this.cache.account != null) ){
          if (this.cache.account.number == num){ 
            console.log("account found in cache");
            this.account = this.cache.account;
            o.next(this.account);
            o.complete();
          }
          else{
            this.cache.account = null;
          }
        }

        //account data was not found in the cache
        //so look up in the DB
      if (this.cache.account == null){  
        console.log("account not found in cache");
        this.acctService.updateCachedAccount(num)
          .subscribe(
            () => {
              
            },
            (err) =>{ console.log(err)},
            () => {
              o.next(this.account);
              o.complete();
            }
          );
      }
    });//this.acctObs
  }//resolve
}
