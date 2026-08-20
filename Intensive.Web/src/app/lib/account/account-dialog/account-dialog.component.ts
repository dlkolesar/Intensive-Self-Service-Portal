
import { Component, OnInit, Output, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { FormControl } from '@angular/forms';
import { Observable, Subject, throwError } from 'rxjs';
import { AccountData } from '../account-data';
import { AccountService } from '../account.service';
import { ServerData } from '../server-data';
import { ServerService } from '../server.service';
import { Exception } from '../../shared-data';
@Component({
  selector: 'ss-account-dialog',
  templateUrl: './account-dialog.component.html',
  styleUrls: ['./account-dialog.component.css']
})
export class AccountDialogComponent implements OnInit {
  
    //@Output() afterClosed = new EventEmitter<number>();
    accountNumber: number;
    acctFrmCtl: FormControl;

    constructor(public dialogRef: MatDialogRef<AccountDialogComponent>,
                public acctService: AccountService,
                public svrService: ServerService) 
    { 
      this.acctFrmCtl = new FormControl();
    }
  
    ngOnInit() { }

     close(){
       console.log("AccountDialogComponent.close()")
     }
  }
  
export class AccountDialog{
  
  dlg: MatDialogRef<AccountDialogComponent>;
  
  
  private readonly _afterClosed = new Subject<number|undefined>();

  constructor (private acctDialog: MatDialog){ }

  open(){
      this.dlg = this.acctDialog.open(AccountDialogComponent);

      this.dlg.afterClosed().subscribe(result => {
        console.log("afterClosed()");
        if (result == undefined){
          this._afterClosed.error('A valid account number is required');
        }
        else{
          this._afterClosed.next(result);
        }
        this._afterClosed.complete();
        
      });
  }

  afterClosed(): Observable<number | undefined>{
    console.log("AccountDialog.afterClosed()");
    return this._afterClosed.asObservable();
  }
  
  close(a){
    console.log("closing....")
    if (!isNaN(a)){
      this.dlg.close(undefined);
    }
    
  }


}
    