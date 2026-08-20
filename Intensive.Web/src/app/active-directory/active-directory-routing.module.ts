import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticatedGuard } from '../lib/auth';

import { CustomerAccessComponent } from './customer-access/customer-access.component';
import { PasswordManagerComponent } from './password-manager/password-manager.component';

const routes: Routes = [
  { path: 'customeraccess', 
    component: CustomerAccessComponent,
    canActivate: [AuthenticatedGuard]
  },
  { path: 'passwordmanager', 
    component: PasswordManagerComponent,
    canActivate: [AuthenticatedGuard]
  },

  // { path: 'admt/{:taskid}', 
  //   component: MigrationResultsComponent,
  //   canActivate: [AuthenticatedGuard]
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActiveDirectoryRoutingModule { 
  constructor(){
    console.log("AD Routing Module constructor");
  }
}
