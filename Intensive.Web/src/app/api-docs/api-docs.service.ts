import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import {ApiDocsMetadata} from './api-docs-metadata';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiDocsService {

  constructor (private http: HttpClient) {}

  getAllApiDocs(): Observable<ApiDocsMetadata[]> {
    let url = environment.apiDocs;
    return this.http.get<ApiDocsMetadata[]>(url);
  }
}
