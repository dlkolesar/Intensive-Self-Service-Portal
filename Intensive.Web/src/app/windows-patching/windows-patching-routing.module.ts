import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WinPatchConfigComponent } from './win-patch-config/win-patch-config.component';
import { AuthenticatedGuard } from '../lib/auth/authenticated.guard';
import { PatchingAdminGuard } from '../lib/auth/patching-admin.guard';
import { ConfigSummaryReportComponent } from './reports/config-summary-report/config-summary-report.component';
import { MissingPatchesReportComponent } from './reports/missing-patches-report/missing-patches-report.component';
import { PatchingReportComponent } from './reports/patching-report/patching-report.component';
import { WinPatchDashboardComponent  } from './win-patch-dashboard/win-patch-dashboard.component';
import { TicketGeneratorConfigComponent } from './ticket-generator/ticket-generator-config/ticket-generator-config.component';
import { TicketGeneratorPreviewComponent } from './ticket-generator/ticket-generator-preview/ticket-generator-preview.component';
import { TicketGeneratorProgressComponent } from './ticket-generator/ticket-generator-progress/ticket-generator-progress.component';
import { TicketGeneratorUpdateComponent } from './ticket-generator';
import { AccountResolverService } from '../lib/account';

const routes: Routes = [
  { 
    path: '', redirectTo: 'dashboard', pathMatch:'full'},
    //component: WinPatchDashboardComponent,
    //canActivate: [AuthenticatedGuard]
    //},
  { 
    path: 'dashboard', 
    component: WinPatchDashboardComponent,
    canActivate: [AuthenticatedGuard],
    resolve: {acct: AccountResolverService },
  },
  { 
    path: 'config', 
    component: WinPatchConfigComponent,
    canActivate: [AuthenticatedGuard],
    resolve: {acct: AccountResolverService },
  },
  { 
    path: 'reports/configsummary', 
    component: ConfigSummaryReportComponent,
    canActivate: [AuthenticatedGuard],
    resolve: {acct: AccountResolverService },
    
  },
  { 
    path: 'reports/missingpatches', 
    component: MissingPatchesReportComponent,
    canActivate: [AuthenticatedGuard],
    resolve: {acct: AccountResolverService },
    
  },
  { 
    path: 'reports/patches', 
    component: PatchingReportComponent,
    canActivate: [AuthenticatedGuard],
    resolve: {acct: AccountResolverService },
    
  },
  { 
    path: 'ticketgenerator/config', 
    component: TicketGeneratorConfigComponent,
    canActivate: [AuthenticatedGuard, PatchingAdminGuard]
    
  },
  { 
    path: 'ticketgenerator/progress', 
    component: TicketGeneratorProgressComponent,
    canActivate: [AuthenticatedGuard, PatchingAdminGuard]
    
  },
  { 
    path: 'ticketgenerator/preview', 
    component: TicketGeneratorPreviewComponent,
    canActivate: [AuthenticatedGuard, PatchingAdminGuard]
    
  },
  { 
    path: 'ticketgenerator/update', 
    component: TicketGeneratorUpdateComponent,
    canActivate: [AuthenticatedGuard, PatchingAdminGuard]
    
  },
  { 
    path: 'ticketgenerator', 
    redirectTo: 'ticketgenerator/config',
    pathMatch: 'full'
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
 
})
export class WindowsPatchingRoutingModule {
  constructor(){
    console.log("Windows Patching Routing Module constructor");
  }
 }
