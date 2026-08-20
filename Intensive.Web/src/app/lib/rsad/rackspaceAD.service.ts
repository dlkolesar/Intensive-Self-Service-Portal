import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

import { rsadUser } from './rsad-user';

@Injectable()
export class rackspaceADService {

  //private baseURL = environment.apiServer + "/edir/test";
  
    constructor (private http: HttpClient) {}
  
    GetUser(userid: string, token: string): Observable<rsadUser> {
      let url = environment.apiCommon + "/proxy";
      let targetURL = environment.apiRackspaceAD + "/user/" + userid + "/";

      let h = new HttpHeaders().set('X-Auth-Token', token);
      let p = new HttpParams().set("url", targetURL);
      
      return this.http.get<rsadUser>(url,{headers:h,params:p});
    }

    // FindUsers(filter: string, attributes:string): Observable<rsadUser[]> {
    //   let url = environment.apiRSAD + "/users?filter=" + filter;
    //   if ( (attributes) && (attributes.length>0) ){
    //     url += "?attributes=" + attributes
    //   }
    //   return this.http.get<rsadUser[]>(url);
    // }
}
