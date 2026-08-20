import { Component, OnInit, Inject, Input } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from '@angular/material';

@Component({
  selector: 'app-progress-bar-dialog',
  templateUrl: './progress-bar-dialog.component.html',
  styleUrls: ['./progress-bar-dialog.component.css']
})

export class ProgressBarDialogComponent implements OnInit {
    pctComplete: number;
    title: string;
    message: string;
    type: string;
    color: string;
  
    constructor(private dialogRef: MatDialogRef<ProgressBarDialogComponent>,
                 @Inject(MAT_DIALOG_DATA) private data: any
    ) {
        this.title = data.title;
        this.type = data.type;
        this.color = data.color;
        this.pctComplete = 0;
        this.message = "";
      }
  
    ngOnInit() {
      
    } 
    
    updateProgress(pct: number, msg:string){
      //if (pct >= 100) { this.dialogRef.close(); }
  
      if (pct < 0) { pct = 0; }
  
      this.pctComplete = pct;
      this.message = msg;
    }
  }
  
  
  export class ProgressBarDialog{
    
      progressPopup: MatDialogRef<ProgressBarDialogComponent>;
  
      constructor (private progressDialog: MatDialog){ 
        
      }
    
    
      open(title, progressType ){
        //if (this.progressDialog.openDialogs.length > 0){
        if ((this.progressPopup) && (this.progressPopup.componentInstance)){
          this.progressPopup.componentInstance.title = title;
          this.progressPopup.componentInstance.pctComplete = 0;
          this.progressPopup.componentInstance.type = progressType;
        }
        else{
          this.progressPopup = this.progressDialog.open(ProgressBarDialogComponent,{
                                    data: {
                                      'title': title,
                                      'type': progressType,
                                      'pctComplete': 0,
                                      'message': ""
                                    }
                                                    
          });
        }//else
      }
    
      updateProgress(pct, msg){
          if (this.progressPopup.componentInstance != null){
           //this.progressPopup.componentInstance.updateProgress(pct, msg);
           this.progressPopup.componentInstance.pctComplete = pct;
           this.progressPopup.componentInstance.message = msg;
         }
      }
    
      close(){
        this.progressPopup.close();
      }

    }
  
