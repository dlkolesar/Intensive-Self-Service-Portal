import { Injectable } from '@angular/core';
//import { Http, Response, RequestOptions, RequestOptionsArgs, Headers } from '@angular/http';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


import { ApiCollection, 
         ApiError,
} from '../lib/shared-data';
import { AuthData } from '../lib/auth';
import { CachingService } from '../lib/caching';
import { Tag } from './models';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TaggingService {

  private apiTagging = environment.apiCommon + "/tags";

  private opts: {
    headers: HttpHeaders,
    params: HttpParams
  };
  private authHeaders: HttpHeaders;
  private auth: AuthData;
                      
  constructor (private http: HttpClient,  
               private cache: CachingService) 
  {

    this.opts = {
      headers: new HttpHeaders(),
      params: new HttpParams()
    };

    this.auth = this.cache.authData;

    this.authHeaders = new HttpHeaders({'X-Auth-Token':this.auth.token, 
                                        'Content-Type':'application/json'});
  }

  getTag(id:number): Observable<Tag> {
    let url = this.apiTagging + "/"  + id;
    return this.http.get<Tag>(url);
  }
  getTagURL(url:string): Observable<Tag> {
    return this.http.get<Tag>(url);
  }

  //public tags
  getPublicTags(): Observable<ApiCollection> {
    let url = this.apiTagging;
    return this.http.get<ApiCollection>(url);
  }

  //private tags
  getPrivateTags(account: number): Observable<ApiCollection> {
    let url = environment.apiCommon + "/accounts/" + account + "/tags";
    return this.http.get<ApiCollection>(url);
  }
  addPrivateTag(account: number, tag:Tag): Observable<any> {
    let url = environment.apiCommon + "/accounts/" + account + "/tags/";
    var data = '"' + tag.tagName + '"';
    return this.http.post(url,data,{headers:this.authHeaders});
  }
  deletePrivateTag(account: number, tag:Tag): Observable<any> {
    let url = environment.apiCommon + "/accounts/" + account + "/tags/" + tag.id;
    return this.http.delete(url,{headers:this.authHeaders})
  }

  //tag-to-server assignments/removal
  assignTag(account: number, server:number, tag:Tag): Observable<any> {
    let url = environment.apiCommon + "/accounts/" + account + "/servers/" + server + "/tags";
    return this.http.post(url, JSON.stringify(tag), {headers: this.authHeaders});
  }

  removeTagAssignment(account: number, server:number, tag:Tag): Observable<any> {
    let url = environment.apiCommon + "/accounts/" + account + "/servers/" + server + "/tags/" + tag.id;
    return this.http.delete(url,{headers: this.authHeaders});
  }

}
