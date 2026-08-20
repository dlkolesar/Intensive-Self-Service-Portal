import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'about', component: AboutComponent }
      ])],
    exports: [RouterModule]
})
export class AboutRoutingModule { }