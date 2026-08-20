import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {  MatCheckboxModule } from '@angular/material/checkbox';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';

import { FlexLayoutModule } from "@angular/flex-layout";
import { ServerListComponent} from './server-list/server-list.component';
import { ServerSelectionComponent} from './server-selection/server-selection.component';
import { ServerFiltersComponent } from './server-filters/server-filters.component';;
import { ServerFilterPipe } from './server-filters/server-filter.pipe';

@NgModule({
  imports: [
    CommonModule,
    MatCheckboxModule,
    MatListModule,
    MatInputModule,
    MatCardModule,
    MatButtonToggleModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    FlexLayoutModule,
    MatSelectModule,
    MatChipsModule
  ],
  declarations: [
    ServerListComponent,
    ServerSelectionComponent,
    ServerFiltersComponent,
    ServerFilterPipe
  ],
  exports:[
    ServerListComponent,
    ServerSelectionComponent,
    ServerFiltersComponent,
    ServerFilterPipe
  ],
    
    providers:[ServerFilterPipe]
})
export class ServerSelectModule {
  constructor(){
    console.log("ServerSelect Module constructor");
  }
 }
