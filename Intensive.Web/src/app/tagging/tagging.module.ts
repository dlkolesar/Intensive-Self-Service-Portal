import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MatCardModule } from "@angular/material/card";
import { MatChipsModule } from "@angular/material/chips";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatTabsModule } from "@angular/material/tabs";
import { MatSelectModule } from "@angular/material/select";
import { MatProgressBarModule  } from "@angular/material/progress-bar";
import { MatDialogModule  } from "@angular/material/dialog";
import { MatListModule  } from "@angular/material/list";

import { FormsModule } from '@angular/forms';
import { TagManagerComponent } from './tag-manager/tag-manager.component';
import { ServerSelectModule } from '../lib/server-select/server-select.module';
import { TagEditorComponent } from './tag-editor/tag-editor.component';
import { TaggingRoutingModule } from './tagging-routing.module';


@NgModule({
  declarations: [TagManagerComponent, TagEditorComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MatCardModule,
    MatChipsModule,
    MatCheckboxModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatTabsModule,
    MatSelectModule,
    MatProgressBarModule,
    MatDialogModule,
    MatListModule,
    FormsModule,
    ServerSelectModule,
    TaggingRoutingModule
  ]
})
export class TaggingModule { }
