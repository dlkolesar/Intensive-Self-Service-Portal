import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgressBarDialogComponent } from './progress-bar-dialog.component';
//import { MatDialogModule } from '@angular/material/dialog';
//import { MatProgressBarModule } from '@angular/material/progress-bar';

import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressBarModule } from '@angular/material/progress-bar';


@NgModule({
  imports: [
    CommonModule,
    MatProgressBarModule,
    MatDialogModule
  ],
  declarations: [ProgressBarDialogComponent],
  entryComponents:[
    ProgressBarDialogComponent
  ]

})
export class ProgressBarDialogModule {
  constructor(){
    console.log("ProgressBarDialog Module constructor");
  }
 }
