
import { Component, OnInit, Output, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatInput, MatIcon,MatButton,
  MatFormField
} from '@angular/material';
import { FormControl, Validators } from '@angular/forms';
import { Observable, Subject, throwError } from 'rxjs';

@Component({
  selector: 'ss-ticket-dialog',
  templateUrl: './ticket-dialog.component.html',
  styleUrls: ['./ticket-dialog.component.css']
})
export class TicketDialogComponent implements OnInit {

    ticketNumber: string;
    ticketNumberFormControl: FormControl;

    constructor(public dialogRef: MatDialogRef<TicketDialogComponent>) 
    { 
      this.ticketNumberFormControl = new FormControl();
      this.ticketNumberFormControl.setValidators([Validators.required,
                                     Validators.pattern(/[0-9]{6}-[0-9]{5}/)]
                                  );     
    }
  
    ngOnInit() {this.ticketNumber = ''; }

    close(){
      console.log("TicketDialogComponent.close()")
    }

    submit(){
      var re = /[0-9]{6}-[0-9]{5}/;

      if (re.test(this.ticketNumber)){
        this.dialogRef.close(this.ticketNumber)
      }

    }
  }
  
export class TicketDialog{
  
  dlg: MatDialogRef<TicketDialogComponent>;
  
  
  private readonly _afterClosed = new Subject<string|undefined>();

  constructor (private tktDialog: MatDialog){ 
    
  }

  open(){
      this.dlg = this.tktDialog.open(TicketDialogComponent);
      this.dlg.disableClose = true;

      this.dlg.afterClosed().subscribe(result => {
        this._afterClosed.next(result);
        this._afterClosed.complete();
      });
  }

  afterClosed(): Observable<string | undefined>{
    console.log("TicketDialog.afterClosed()");
    
    return this._afterClosed.asObservable();
  }
  
  close(a){
    console.log("closing....")
    this.dlg.close(undefined);
  }


}
    