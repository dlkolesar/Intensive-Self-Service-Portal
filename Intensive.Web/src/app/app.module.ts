import { BrowserModule } from "@angular/platform-browser";
import { NgModule, APP_INITIALIZER } from "@angular/core";
import { FlexLayoutModule } from "@angular/flex-layout";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import {
  
  MatToolbarModule,
  MatButtonModule,
  MatMenuModule,
  MatIconModule,
  MatSidenavModule,
  MatExpansionModule,
  MatListModule,
  MatGridListModule,
  MatProgressSpinnerModule,
  MatDialogModule,
  MatInputModule

  
} from "@angular/material";

import { AppComponent } from "./app.component";
import { TicketDialogComponent } from './lib/ticket-dialog/ticket-dialog.component';
import { AboutModule } from "./lib/about/about.module";
import { AricModule } from './aric';
import { AccountModule } from "./lib/account";

import { CachingModule } from "./lib/caching";
import { ProgressBarDialogModule } from './lib/progress-bar-dialog';
import { ErrorDialogModule } from './lib/error-dialog';
import { ConfirmationDialogModule } from './lib/confirmation-dialog';
import { AppConfigService } from './lib/shared-data';

import { WindowsPatchingModule } from './windows-patching/windows-patching.module';
import { ActiveDirectoryModule } from './active-directory';
import { AuditingModule, AuditReportComponent } from './auditing';
import { SAMLAuthComponent } from './lib/auth';
import { AccountDashboardComponent } from './account-dashboard/account-dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { ApiDocsModule } from './api-docs';
//import { TaggingModule } from './tagging';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent, 
    SAMLAuthComponent, 
    AccountDashboardComponent,
    TicketDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatSidenavModule,
    MatExpansionModule,
    MatListModule,
    MatGridListModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatInputModule,
    //TaggingModule,
    AboutModule,
    AccountModule,
    AricModule,
    CachingModule,
    ProgressBarDialogModule,
    ErrorDialogModule,
    ConfirmationDialogModule,
    AppRoutingModule,
    ActiveDirectoryModule,
    WindowsPatchingModule,
    AuditingModule,
    ApiDocsModule
  ],
  providers: [
    AppConfigService,
      { 
        provide: APP_INITIALIZER, 
        useFactory: loadConfig, 
        deps: [AppConfigService], 
        multi: true 
      }
  ],
  entryComponents:[TicketDialogComponent],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(){
    console.log("APP Module constructor");
  }
}


export function loadConfig(config: AppConfigService) {
  return () => { 
    return config.load();
  }
}
