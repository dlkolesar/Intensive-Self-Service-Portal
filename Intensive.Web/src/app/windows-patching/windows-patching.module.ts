import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MatCardModule } from "@angular/material/card";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatRadioModule } from "@angular/material/radio";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatTableModule } from "@angular/material/table";
import { MatTabsModule } from "@angular/material/tabs";
import { MatSelectModule } from "@angular/material/select";
import { MatButtonToggleModule } from "@angular/material/button-toggle";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MatSortModule } from "@angular/material/sort";
import { MatProgressBarModule  } from "@angular/material/progress-bar";

import { FormsModule } from '@angular/forms';

import { AuthenticatedGuard } from '../lib/auth/authenticated.guard';
import { AuthService } from '../lib/auth/auth.service';
import { ServerSelectModule } from '../lib/server-select/server-select.module';
import { ProgressBarDialogModule } from '../lib/progress-bar-dialog';
import { ErrorDialogModule } from '../lib/error-dialog';

import { CoreService } from '../lib/core/core.service';
import { WindowsPatchingRoutingModule } from './windows-patching-routing.module';
import { WinPatchConfigComponent } from './win-patch-config/win-patch-config.component';
import { PatchingAdminGuard } from '../lib/auth/patching-admin.guard';
import { WinPatchConfigAccountComponent } from './win-patch-config-account/win-patch-config-account.component';
import { WinPatchConfigClientComponent } from './win-patch-config-client/win-patch-config-client.component';
import { WinPatchService } from './win-patch.service';
import { WinPatchCalendarComponent } from './win-patch-calendar/win-patch-calendar.component';
import { ConfigSummaryReportComponent, 
        MissingPatchesReportComponent } from './reports';
import { WinPatchDashboardComponent } from './win-patch-dashboard/win-patch-dashboard.component'
import { TicketGeneratorConfigComponent, 
         TicketGeneratorPreviewComponent, 
         TicketGeneratorProgressComponent,
         TicketGeneratorUpdateComponent } from './ticket-generator';
import { PatchingReportComponent } from './reports/patching-report/patching-report.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    WindowsPatchingRoutingModule,
    ServerSelectModule,
    FlexLayoutModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatInputModule,
    MatSlideToggleModule,
    MatExpansionModule,
    MatTableModule,
    MatTabsModule,
    MatRadioModule,
    MatSelectModule,
    MatSortModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonToggleModule,
    ProgressBarDialogModule,
    ErrorDialogModule,
    MatProgressBarModule
  ],
  declarations: [  
    WinPatchConfigComponent, 
    WinPatchConfigAccountComponent, 
    WinPatchConfigClientComponent, 
    WinPatchCalendarComponent,
    ConfigSummaryReportComponent,
    MissingPatchesReportComponent,
    WinPatchDashboardComponent,
    TicketGeneratorConfigComponent,
    TicketGeneratorPreviewComponent,
    TicketGeneratorProgressComponent,
    TicketGeneratorUpdateComponent,
    PatchingReportComponent 
  ],
  exports: [ WinPatchCalendarComponent ],
  providers: [
    PatchingAdminGuard,
    AuthenticatedGuard, 
    AuthService, 
    WinPatchService,
    CoreService
  ]
  
})
export class WindowsPatchingModule {
  constructor(){
    console.log("Windows Patching Module constructor");
  }
 }
