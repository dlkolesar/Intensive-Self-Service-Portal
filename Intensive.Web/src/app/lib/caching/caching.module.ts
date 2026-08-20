import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CachingService } from './caching.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers:[CachingService]
})
export class CachingModule { 
  constructor(){
    console.log("Caching Module constructor");
  }
}
