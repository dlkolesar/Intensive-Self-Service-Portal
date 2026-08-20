import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { PatchingAccount } from '../models/patching-account';

@Component({
  selector: 'ss-win-patch-config-account',
  templateUrl: './win-patch-config-account.component.html',
  styleUrls: ['./win-patch-config-account.component.css']
})
export class WinPatchConfigAccountComponent implements OnInit {

  @Input() account: PatchingAccount;

  @Output() change = new EventEmitter<AccountChanges>();


  constructor() { }

  ngOnInit() {
  }


  AccountOptInOut(){
    let chg = new AccountChanges();
    chg.accountOptOut = this.account.optedOut;
    this.change.emit(chg);
  }


  PatchingTicketOptInOut(){
    let chg = new AccountChanges();
    chg.ticketingOptOut = this.account.optedOutOfTicketing;
    this.change.emit(chg);
  }

}

export class AccountChanges{
  accountOptOut: boolean;
  ticketingOptOut: boolean

  constructor(){

  }
}
