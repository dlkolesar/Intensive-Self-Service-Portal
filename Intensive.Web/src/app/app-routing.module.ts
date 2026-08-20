
import { NgModule } from "@angular/core";

import { RouterModule, Routes, RouterOutlet } from "@angular/router";

import { AccountResolverService } from "./lib/account";


import { WindowsPatchingModule } from './windows-patching/windows-patching.module';
import { ActiveDirectoryModule } from './active-directory';

import { AuditReportComponent } from './auditing';
import { SAMLAuthComponent } from './lib/auth';
import { AccountDashboardComponent } from './account-dashboard/account-dashboard.component';
import { TagManagerComponent, TagEditorComponent } from './tagging';

export const appRoutes: Routes = [
    { 
      path: 'auth', 
      component: SAMLAuthComponent,
    },
    { 
      path: 'apidocs', 
      loadChildren: () => import('./api-docs/api-docs.module').then(m=>m.ApiDocsModule)
    },
    { 
      path: 'ad', 
      loadChildren: () => import('./active-directory/active-directory.module').then(m=>m.ActiveDirectoryModule)
    },
    { 
      path: 'audit', 
      component: AuditReportComponent,
    },
    { 
      path: 'windowspatching', 
      loadChildren: () => import('./windows-patching/windows-patching.module').then(m=>m.WindowsPatchingModule)
    },
    { 
      path: ':acct/ad', 
      loadChildren: () => import('./active-directory/active-directory.module').then(m=>m.ActiveDirectoryModule),
      //resolve: {acct: AccountResolverService },
      //pathMatch: 'full' 
    },
    // { 
    //   path: ':acct/tags', 
    //   loadChildren: () => import('./tagging/tagging.module').then(m=>m.TaggingModule),
    //   //component: TagManagerComponent,
    //   //resolve: {acct: AccountResolverService } 
    // },
    // { 
    //   path: ':acct/tags/editor', 
    //   //loadChildren: () => import('./tagging/tagging.module').then(m=>m.TaggingModule)
    //   component: TagEditorComponent,
    //   resolve: {acct: AccountResolverService } 
    // },
     { 
      path: ':acct/windowspatching', 
      loadChildren: () => import('./windows-patching/windows-patching.module').then(m=>m.WindowsPatchingModule),
      //resolve: {acct: AccountResolverService } ,
      //pathMatch: 'full' 

    },
    { 
      path: ':acct', 
      component: AccountDashboardComponent,
      resolve: {acct: AccountResolverService } 
    },
    { 
      path: '', 
      redirectTo: '', 
      pathMatch: 'full'  
    },
    { 
      path: "**", 
      redirectTo: "/",
      pathMatch: 'full' 
    }, //create a "Not Found/Invalid Route" component?????
  ];


  @NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes,
        { enableTracing: true } // <-- debugging purposes only
      )
    ],
    exports: [
      RouterModule
    ]
  })

  export class AppRoutingModule {}