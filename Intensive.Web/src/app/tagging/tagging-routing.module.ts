
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountResolverService } from "../lib/account";
import { AuthenticatedGuard } from '../lib/auth/authenticated.guard';
import { TagManagerComponent } from './tag-manager/tag-manager.component';
import { TagEditorComponent } from './tag-editor/tag-editor.component';


const routes: Routes = [
  
    // { 
    //     path: '', 
    //     component: TagManagerComponent,
    //     canActivate: [AuthenticatedGuard],
    //     resolve: {acct: AccountResolverService }
    //     //redirectTo: 'manager', 
    //     //pathMatch:'full'
    // },
    { 
        path: 'manager', 
        component: TagManagerComponent,
        canActivate: [AuthenticatedGuard],
        resolve: {acct: AccountResolverService } 
    },
    { 
        path: 'editor', 
        component: TagEditorComponent,
        canActivate: [AuthenticatedGuard],
        resolve: {acct: AccountResolverService } 
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
 
})
export class TaggingRoutingModule {
  constructor(){
    console.log("Tagging Routing Module constructor");
  }
 }
