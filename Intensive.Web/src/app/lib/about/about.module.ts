import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about.component';
import { FormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
    FormsModule,
    FlexLayoutModule
  ],
  declarations: [AboutComponent],
  providers:  [],
  entryComponents: [
    AboutComponent
  ],
  exports:[AboutComponent]
})

export class AboutModule { 
  constructor(){
    console.log("About Module constructor");
  }
}
