import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AricService } from './aric-service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers:  [AricService],
  entryComponents: [
  ],
})
export class AricModule {

  constructor(){
    console.log("ARIC Module constructor");
  }
 }
