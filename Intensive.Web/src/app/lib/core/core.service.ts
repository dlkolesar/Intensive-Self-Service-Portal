

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import { ApiCollection, 
//          ApiError,
// } from '../lib/shared-data';

import { AuthData } from '../../lib/auth';

import { CachingService } from '../../lib/caching';

// import {PatchingAccount,
//         PatchingClient,
//         MissingPatchData, 
//         TicketGeneratorConfiguration,
//         PatchingTicketHistory
// } from './models';


import { environment } from '../../../environments/environment';





@Injectable()
export class CoreService {

  
  coreURL = environment.apiCORE + "/proxy";
  
  headers      = new HttpHeaders({ 'Content-Type': 'application/json;charset=utf-8', 
                                    'Accept':'application/json' });
  
  constructor (private http: HttpClient) { 
    
    
  }

  getCoreToken(baseURL: string, user: string, pwd:string): Observable<any>{

    let data: CoreProxyData = new CoreProxyData();
    data.url = baseURL + '/ctkapi/login/' + user;

    data.token = "";
    data.jsonData = JSON.parse('{"password":"' + pwd + '"}');
    
    
    return this.http.post(this.coreURL, data, { headers: this.headers });
  }

  getTicket(baseURL: string, token: string, ticket: string): Observable<any>{

    this.headers      = new HttpHeaders(
        { 'Content-Type': 'application/json;charset=utf-8', 
          'Accept':'application/json' ,
          'X-Auth': token
        });
    let data: CoreProxyData = new CoreProxyData();
    data.url = baseURL + '/ctkapi/query';

    data.token = token;
    var json = '{"class": "Ticket.Ticket",';
    json += '"load_arg": "' + ticket +'",';
    json += '"attributes": ["subject"]';
    json += '}';

    data.jsonData = JSON.parse(json);

    return this.http.post(this.coreURL, data, { headers: this.headers });
  }


  addTicketComment(baseURL: string, token: string, ticket: string, comment:string, privateComment:boolean): Observable<any>{

    var escComment = comment
    escComment = escComment.replace(/\r\n/gi,"\\n");
    escComment = escComment.replace(/\n/gi, "\\n");
    escComment = escComment.replace(/\t/gi, "\\t");
    this.headers      = new HttpHeaders(
        { 'Content-Type': 'application/json;charset=utf-8', 
          'Accept':'application/json' ,
          'X-Auth': token
        });
    let data: CoreProxyData = new CoreProxyData();
    data.url = baseURL + '/ctkapi/query';

    data.token = token;
    var json = '{"class": "Ticket.Ticket",';
    json += '"load_arg": "' + ticket +'",';
    json += '"method": "addMessage",';

    var strArr = '[';
    strArr += '"' + escComment + '",';
    strArr += '3,';
    strArr += (privateComment) ? '1': '0';
    strArr += ']';
    
    json += '"args": ' + strArr + ',';
    json +=  '"keyword_args": {}';
    json += '}';

    data.jsonData = JSON.parse(json);

    return this.http.post(this.coreURL, data, { headers: this.headers });
  }
}

export class CoreProxyData{
  url: string;
  token: string;
  jsonData: object;
}