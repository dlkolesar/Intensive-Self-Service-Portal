import { Component, OnInit, Input, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from '@angular/material';

import { ApiError, Exception } from '../shared-data';


@Component({
  selector: 'app-error-dialog',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.css']
})
export class ErrorDialogComponent implements OnInit {
  title: string;
  message: string;
  icon: string;
  url: string;
  
  iconColor: string;

  constructor(public dialogRef: MatDialogRef<ErrorDialogComponent>,
               @Inject(MAT_DIALOG_DATA) public data: any
  ) {
      this.title = data.title;
      this.message = data.message;
      this.icon = data.icon;
      this.url = data.url;

      switch(this.icon.toLowerCase()){
        case 'error': this.iconColor = "darkred"; break;
        case 'warning': this.iconColor = "darkorange"; break;
        case 'check_circle': this.iconColor = "darkgreen"; break;
        case 'info': this.iconColor = "blue"; break;
      }
  }


  ngOnInit() {
  }
  
  close(){
    this.dialogRef.close();
  }
}

export class ErrorDialog{
  
  errorPopup: MatDialogRef<ErrorDialogComponent>;

  constructor (private errorDialog: MatDialog){}

  open(title, msg, url, icon ){
      this.errorPopup = this.errorDialog.open(ErrorDialogComponent,{
                                data: {
                                  title: title,
                                  message: msg,
                                  url: url,
                                  icon: icon
                                }
                                                
      });
    }

    openApiError(title: string, apiErr: ApiError){
      var msg = "API Error " + apiErr.errorCode + ": " + apiErr.message;
      this.open(title, msg, apiErr.help, "error");
    }

    showError(title, err, url, icon){
      if ( (err.error) && (err.error.errorCode) ){
        var msg = "API Error " + err.error.errorCode + ": " + err.error.message;
        this.open(title, msg, err.error.help, icon);
      }
      else{ 
        this.open(title, "Error communicating with API: \r\n" + err.message,"","error");
      }
    }
  
    close(){
      this.errorPopup.close();
    }
}
  
