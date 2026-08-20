import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';


import { ApiDocsRoutingModule } from './api-docs-routing.module';
import { DocumentIndexComponent } from './document-index/document-index.component';
import { SwaggerUIComponent } from './swagger-ui/swagger-ui.component';
import { ApiDocsService } from './api-docs.service';
import { ApiPrimerComponent } from './api-primer/api-primer.component';

@NgModule({
  imports: [
    CommonModule,
    ApiDocsRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatGridListModule,
    MatListModule,
    MatExpansionModule
  ],
  declarations: [DocumentIndexComponent, SwaggerUIComponent, ApiPrimerComponent],
  providers: [ApiDocsService]
})
export class ApiDocsModule { }
