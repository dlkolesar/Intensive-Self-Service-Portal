import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuditReportComponent } from './audit-report/audit-report.component';
import { AuthenticatedGuard } from '../lib/auth/authenticated.guard';
import { PatchingAdminGuard } from '../lib/auth/patching-admin.guard';

const routes: Routes = [
  // use with --prod to lazy-loading feature modules
  //{ path: '', component: AuditReportComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
 
})
export class AuditingRoutingModule {
  constructor(){
    console.log("Audit Routing Module constructor");
  }
 }
