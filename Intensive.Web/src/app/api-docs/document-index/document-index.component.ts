import { Component, OnInit } from '@angular/core';
import {
  Router,
  ActivatedRoute,
  Params,
  ActivationStart
} from "@angular/router";
import { MatDialog} from "@angular/material";

import { ApiDocsService } from '../api-docs.service';
import { ApiDocsMetadata } from '../api-docs-metadata';
import { environment } from '../../../environments/environment';
import { CachingService } from '../../lib/caching';
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';

@Component({
  selector: 'app-document-index',
  templateUrl: './document-index.component.html',
  styleUrls: ['./document-index.component.css']
})
export class DocumentIndexComponent implements OnInit {

  apidocs: ApiDocsMetadata[];
  categories: string[];
  
  errorDialog: ErrorDialog;
  progressDialog: ProgressBarDialog;

  constructor(private router: Router,
              private repo: ApiDocsService,
              private cache: CachingService, 
              private dlgError: MatDialog,
              private dlgProgress: MatDialog,) {
    this.cache.hideAccount(); //hide the account in the banner
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.progressDialog = new ProgressBarDialog(this.dlgProgress);
   }

  ngOnInit() {
    this.progressDialog.open("API Documentation", "indeterminate");
    this.progressDialog.updateProgress(-1, "Collecting documentation files....");
    this.repo.getAllApiDocs()
      .subscribe(
        d => {
          this.apidocs = d;
          this.categories = [];
          d.forEach( (v,i,a) =>{
            if (!this.categories.includes(v.category))
            {
              this.categories.push(v.category);
            }
          });
          this.progressDialog.close();
        },
        err => {
          this.progressDialog.close();
          this.errorDialog.openApiError("API Documentation", err);
        }
      )
  }

  DocsInCategory(cat: string):ApiDocsMetadata[]{
    return this.apidocs.filter(v => v.category.toLowerCase() == cat.toLowerCase())
  }
  DocToURL(doc: ApiDocsMetadata){
    let url = environment.apiDocs + '/openapidocs/' + doc.category + '/' + doc.title + '/' + doc.fileName;
    return '/apidocs/view?url=' + encodeURI(url);
  }
  iconURL(doc: ApiDocsMetadata){
    //let url = environment.documentationAPI + '/openapidocs/'
    if (doc.iconFileName == '') {return ''}
    
    let url = environment.apiDocs + '/openapidocs/' + doc.category + '/' + doc.title + '/' + doc.iconFileName;
    return url;

  }

  routeTo(doc: ApiDocsMetadata){
    //window.location.href = this.DocToURL(doc);
    var docurl = environment.apiDocs + '/openapidocs/' + doc.category + '/' + doc.title + '/' + doc.fileName;
    var segments = ['/','apidocs', "view"]
    var qs = {queryParams: {url: encodeURI(docurl)}};

    this.router.navigate(segments, qs);

  }
}
