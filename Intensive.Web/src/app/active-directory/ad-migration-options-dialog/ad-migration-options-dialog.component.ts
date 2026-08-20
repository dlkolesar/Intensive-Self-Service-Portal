import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
//import { FormControl } from '@angular/forms';
//import { Observable, Subject, throwError } from 'rxjs';


@Component({
  selector: 'ss-ad-migration-options-dialog',
  templateUrl: './ad-migration-options-dialog.component.html',
  styleUrls: ['./ad-migration-options-dialog.component.css']
})
export class AdMigrationOptionsDialogComponent implements OnInit {
  options: string;

  

  showGroupOptions: boolean;
  showUserOptions: boolean;
  showComputerOptions: boolean;

  constructor (public dialogRef: MatDialogRef<AdMigrationOptionsDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any){

        this.showComputerOptions = data.showComputerOptions;
        this.showGroupOptions = data.showGroupOptions;
        this.showUserOptions = data.showUserOptions;
     }

  ngOnInit() {
  }

  close(){
    
  }
}
