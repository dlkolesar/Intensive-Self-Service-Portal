import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { ErrorDialogComponent } from './error-dialog.component';



@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MatIconModule,
    MatButtonModule
  ],
  declarations: [ErrorDialogComponent],
  entryComponents:[
    ErrorDialogComponent
  ]
})
export class ErrorDialogModule { }
