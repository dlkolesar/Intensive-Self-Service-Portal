import { Component, OnInit, Input, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from '@angular/material';
import { Observable, Subject, throwError } from 'rxjs';
import { ApiError, Exception } from '../shared-data';


@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnInit {
  title: string;
  message: string;
  icon: string;
  url: string;
  
  answer: boolean;

  constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
               @Inject(MAT_DIALOG_DATA) public data: any) {

  }


  ngOnInit() {
  }
  
  close(result){
    this.dialogRef.close(result);
  }
}

export class ConfirmationDialog{
  
  dlg: MatDialogRef<ConfirmationDialogComponent>;
  
  
  private readonly _afterClosed = new Subject<number|undefined>();

  constructor (private confirmationDialog: MatDialog){ }

  open(title, msg, q){
      this.dlg = this.confirmationDialog.open(
                    ConfirmationDialogComponent,{
                          data: {
                            title: title,
                            message: msg,
                            question: q
                          }
                        });

      this.dlg.afterClosed().subscribe(result => {
        console.log("afterClosed()");
        this._afterClosed.next(result);
        this._afterClosed.complete();
        
      });
  }

  afterClosed(): Observable<number | undefined>{
    console.log("ConfirmationDialog.afterClosed()");
    return this._afterClosed.asObservable();
  }
  
  close(a){
    console.log("closing....")
    this.dlg.close(a);
  }

}
