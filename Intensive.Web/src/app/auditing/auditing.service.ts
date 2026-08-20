import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuditEntry } from './audit-entry';
import { ApiCollection } from '../lib/shared-data';
import { environment } from '../../environments/environment';

@Injectable()
export class AuditingService {

  constructor (private http: HttpClient) { }

  FindAuditEntries(id, account,device, sso, action){
    let url = environment.apiAuditing;
    var qs = '';

    if ((id) && (id>-1)) {qs += '&systemid=' + id;}

    if (account) {qs += '&account=' + account;}

    if (device) {qs += '&device=' + device;}

    if (sso) {qs += '&userid=' + sso;}

    if (action) {qs += '&action=' + action;}

    
    if (qs != ''){qs = qs.replace('&', '?');} //change the first & to a ?
    
    url += qs;
    console.log(url);
    return this.http.get<ApiCollection>(url);
  }

  GetAuditEntry(id: number){
    let url = environment.apiAuditing + '/' + id;
    return this.GetAuditURL(url)
  }

  GetAuditURL(url: string){
    return this.http.get<AuditEntry>(url);
  }

}
