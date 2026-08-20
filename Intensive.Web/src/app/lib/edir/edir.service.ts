import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

import { eDirUser } from './edir-user';

@Injectable()
export class eDirService {

  //private baseURL = environment.apiServer + "/edir/test";
  
    constructor (private http: HttpClient) {}
  
    GetUser(userid: string, attributes:string): Observable<eDirUser> {
      let url = environment.apiRSAD + "/users/" + userid;
      if ( (attributes) && (attributes.length>0) ){
        url += "?attributes=" + attributes
      }
      return this.http.get<eDirUser>(url);
    }

    FindUsers(filter: string, attributes:string): Observable<eDirUser[]> {
      let url = environment.apiRSAD + "/users?filter=" + filter;
      if ( (attributes) && (attributes.length>0) ){
        url += "?attributes=" + attributes
      }
      return this.http.get<eDirUser[]>(url);
    }
}
