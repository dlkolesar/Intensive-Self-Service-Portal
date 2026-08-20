import {AfterViewInit, Component, ElementRef,  OnInit, Input} from '@angular/core';
import {
  Router,
  ActivatedRoute,
  Params,
  ActivationStart,
  NavigationEnd
} from "@angular/router";

import SwaggerUI from 'swagger-ui';
import { ApiDocsMetadata } from '../api-docs-metadata';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-swagger-ui',
  templateUrl: './swagger-ui.component.html',
  styleUrls: ['./swagger-ui.component.css']
})
export class SwaggerUIComponent implements OnInit, AfterViewInit {

  //@Input() doc: ApiDocsMetadata;

  url: string;
  componentHeight: number;

  constructor(private el: ElementRef, private route: ActivatedRoute,) {
    this.route.queryParams.subscribe((p: Params) => {
      this.url = p["url"];
    });

    //this.url = environment.apiDocs + '/openapidocs/' + this.doc.category + '/' + this.doc.title + '/' + this.doc.fileName;
  }

  ngOnInit() {
    this.componentHeight = window.innerHeight - 100;
  }


  ngAfterViewInit() {
    const ui = SwaggerUI({
      //url: 'http://petstore.swagger.io/v2/swagger.json',
      url: encodeURI(this.url),
      domNode: this.el.nativeElement.querySelector('.swagger-container')
    });
  }
}
