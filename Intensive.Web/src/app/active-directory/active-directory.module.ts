import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';

import {MatExpansionModule} from '@angular/material/expansion';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatTreeModule} from '@angular/material/tree';
import {MatTableModule} from '@angular/material/table';
import {MatSortModule} from '@angular/material/sort';
import {MatDialogModule} from '@angular/material/dialog';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ProgressBarDialogModule } from '../lib/progress-bar-dialog';
import { ErrorDialogModule } from '../lib/error-dialog';

import { ActiveDirectoryRoutingModule } from './active-directory-routing.module';
import { ActiveDirectoryService } from './active-directory.service';
import { AuthService, AuthenticatedGuard } from '../lib/auth';
import { rackspaceADService  } from '../lib/rsad';
import { eDirService } from '../lib/edir';
import { MigratorComponent } from './migrator/migrator.component';
import { ObjectCheckListComponent } from './object-check-list/object-check-list.component';

import { AdObjectTreeComponent } from './ad-object-tree/ad-object-tree.component';
import { ExportToCSVModule } from '../lib/export-to-csv/export-to-csv.module';
import { CustomerAccessComponent } from './customer-access/customer-access.component';
import { PasswordManagerComponent } from './password-manager/password-manager.component';
import { AdUserSelectComponent } from './ad-user-select/ad-user-select.component';
import { AdMigrationOptionsDialogComponent } from './ad-migration-options-dialog/ad-migration-options-dialog.component';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ActiveDirectoryRoutingModule,
    FlexLayoutModule,
    MatExpansionModule,
    MatCardModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCheckboxModule,
    MatDialogModule,
    MatListModule,
    MatIconModule,
    MatInputModule,
    MatTreeModule,
    MatTableModule,
    MatSortModule,
    MatProgressSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    ProgressBarDialogModule,
    ErrorDialogModule,
    ExportToCSVModule
  ],
  declarations: [
    MigratorComponent, 
    ObjectCheckListComponent,  
    AdObjectTreeComponent, 
    CustomerAccessComponent, 
    PasswordManagerComponent,
    AdUserSelectComponent, 
    AdMigrationOptionsDialogComponent
  ],
  providers: [
    eDirService, 
    rackspaceADService,
    AuthService, 
    ActiveDirectoryService,
    AuthenticatedGuard
  ],
  entryComponents:[
    AdMigrationOptionsDialogComponent
  ]
})
export class ActiveDirectoryModule { 

  constructor(){
    console.log("AD Module constructor");
  }
}
