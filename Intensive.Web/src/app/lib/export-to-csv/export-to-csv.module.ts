
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";


import { ExportToCSVComponent } from './export-to-csv.component';

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule
  ],
  declarations: [ExportToCSVComponent],
  providers: [ ],
  entryComponents:[ ],
  exports: [ExportToCSVComponent]
})
export class ExportToCSVModule { 
  constructor(){
    console.log("ExportToCSV Module constructor");
  }
}
