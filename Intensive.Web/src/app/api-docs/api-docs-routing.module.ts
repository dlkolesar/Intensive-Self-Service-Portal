import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SwaggerUIComponent } from './swagger-ui/swagger-ui.component';
import { DocumentIndexComponent } from './document-index/document-index.component';
import { ApiPrimerComponent } from './api-primer/api-primer.component';

export const appRoutes: Routes = [
  
  { 
    path: 'view', 
    component: SwaggerUIComponent
  },
  { 
    path: 'view/primer', 
    component: ApiPrimerComponent
  },

  { 
    path: '', 
    component: DocumentIndexComponent, 
    pathMatch: 'full'  
  },
  { 
    path: "**", 
    redirectTo: "/",
    pathMatch: 'full' 
  } //create a "Not Found/Invalid Route" component?????
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  exports: [RouterModule]
})
export class ApiDocsRoutingModule { }
