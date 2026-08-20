import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';


import { AccountData } from './account-data';
import { AccountService } from './account.service';
import { AccountResolverService } from './account-resolver.service';
import { ServerData } from './server-data';
import { ServerService } from './server.service';
import { AccountDialog, AccountDialogComponent } from './account-dialog/account-dialog.component';
import { ProgressBarDialogModule } from '../progress-bar-dialog';
import { TaggingModule } from '../../tagging/';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatInputModule,
    ProgressBarDialogModule,
    TaggingModule
  ],
  declarations: [AccountDialogComponent],
  providers: [AccountService, ServerService, AccountResolverService ],
  entryComponents: [AccountDialogComponent]
})

export class AccountModule { 
  constructor(){
    console.log("Account Module constructor");
  }
}
