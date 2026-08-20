import { Injectable } from '@angular/core';

import { AccountData } from '../account/account-data';
import { AuthData } from '../auth/auth-data';


import { Subject  }    from 'rxjs';
// import { BehaviorSubject }    from 'rxjs/BehaviorSubject';
// import { Observable } from 'rxjs';

@Injectable()
export class CachingService {

  private acct = new Subject<AccountData>();
  Account$ = this.acct.asObservable();

  private _account: AccountData;
  get account(): AccountData{ 
    if (window.sessionStorage.getItem("accountData")){
      this._account = JSON.parse(window.sessionStorage.getItem("accountData"));
      return this._account;
    }
    else{
      return null;
    }
  }
  set account(newAcct: AccountData){
    this._account = newAcct;
    if (newAcct){
      window.sessionStorage.setItem("accountData", JSON.stringify(newAcct));
      this.acct.next(newAcct);
    }
    else{ //if newAcct is null/undefined, remove it from the cache
        window.sessionStorage.removeItem("accountData");
    }
  }
  hideAccount(){
    this._account = this.account;
    if (this._account){
      this._account.show = false;
      this.account = this._account;
    }
  }
  showAccount(){
    this._account = this.account;
    if (this._account){
      this._account.show = true;
      this.account = this._account;
    }

  }

  private _authData: AuthData;
  private auth = new Subject<AuthData>();
  Auth$ = this.auth.asObservable();

  get authData(): AuthData{ 
    var tmp = window.sessionStorage.getItem("authData");
    if (tmp){
      this._authData = new AuthData(tmp);
      return this._authData;
    }
    else{
      return null;
    }
  }

  set authData(newAuth:AuthData){ 
    if (newAuth){
      window.sessionStorage.setItem("authData", JSON.stringify(newAuth.identityData));
      this.auth.next(newAuth);
    }
    else{ //if newAcct is null/undefined, remove it from the cache
        window.sessionStorage.removeItem("authData");
    }
  }

  constructor() { }

  

}
