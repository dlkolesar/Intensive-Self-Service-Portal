import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { Observable } from 'rxjs';

import 'rxjs/add/operator/map'; 

import { ApiCollection } from '../shared-data/api-collection';
import { ServerData } from './server-data';



@Injectable()
export class ServerService {

  private commonURL: string;

  constructor (private http: HttpClient) {
  }


  getServersForAccount(acct): Observable<ApiCollection> {
    let url = environment.apiCommon + "/accounts/" + acct + "/servers/"
    var systemName:string;
    return this.http.get<ApiCollection>(url);
  }

  getServerByURL(url): Observable<ServerData> {
    return this.http.get<ServerData>(url);
  }

  getServer(num): Observable<ServerData> {
    let url = environment.apiCommon + "/servers/" + num;
    return this.http.get<ServerData>(url);
  }

}
