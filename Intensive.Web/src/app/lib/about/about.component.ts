import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef,MAT_DIALOG_DATA} from '@angular/material';
import {environment} from '../../../environments/environment';


@Component({
  selector: 'ss-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {

  version: string;
  title: string;

  constructor (public dialogRef: MatDialogRef<AboutComponent>)
  { 
    this.version = environment.appVersion;
    this.title = environment.siteTitle;
  }

  ngOnInit() {
  }
}
