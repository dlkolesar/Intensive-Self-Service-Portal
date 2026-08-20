
import { Injectable } from '@angular/core';
//import { Http, Response, RequestOptions, RequestOptionsArgs, Headers } from '@angular/http';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ApiCollection, 
         ApiError,
} from '../lib/shared-data';

import { AuthData } from '../lib/auth';

import { CachingService } from '../lib/caching';

import {PatchingAccount,
        PatchingClient,
        MissingPatchData, 
        TicketGeneratorConfiguration,
        PatchingTicketHistory,
        PatchStatus
} from './models';


import { environment } from '../../environments/environment';


@Injectable()
export class WinPatchService {

  private ticketGeneratorURL = environment.apiWinPatch + "/ticketgenerator";

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

    this.opts.headers = new HttpHeaders({'X-Auth-Token':this.auth.token, 'Content-Type':'application/json'});
  }


//PatchingAccount services  
  getPatchingAccount(num): Observable<PatchingAccount> {
    let url = environment.apiWinPatch + "/accounts/"  + num;
    return this.http.get<PatchingAccount>(url);
  }

  getPatchingAccountsOptedIn(): Observable<ApiCollection> {
    let url = environment.apiWinPatch + "/accounts";
    return this.http.get<ApiCollection>(url);
  }

  AccountOptInOut(acct:number, optOut:boolean, ticket: string){
    var opt = (optOut)?"optout":"optin"
    let url = environment.apiWinPatch + "/accounts/" + acct + "?action=" + opt + '&ticket=' + ticket;

    return this.http.post(url, null, {headers:this.opts.headers});
  }

  AccountRefresh(acct:number):Observable<ApiCollection>{
    let url = environment.apiWinPatch + "/accounts/" + acct + "?action=refresh";

    return this.http.post<ApiCollection>(url, null, {headers:this.opts.headers});
  }

  savePatchingAccount(acct: PatchingAccount): Observable<PatchingAccount> {
    let url = environment.apiWinPatch + "/accounts/" + acct.number;
    let bodyString = JSON.stringify(acct); // Stringify payload
    
    return this.http.put<PatchingAccount>(url,bodyString,{headers:this.opts.headers});
  }

//PatchingClient services  
  getPatchingClients(acct: number): Observable<ApiCollection> {
    let url = environment.apiWinPatch + "/accounts/" + acct + "/clients";
    return this.http.get<ApiCollection>(url);
  }

  getPatchingClientResource(url): Observable<PatchingClient> {
    return this.http.get<PatchingClient>(url, {headers:this.opts.headers})
  }

  getPatchingClient(deviceNumber: number): Observable<PatchingClient> {
    let url = environment.apiWinPatch + "/clients/"  + deviceNumber;
    return this.http.get<PatchingClient>(url, {headers:this.opts.headers});
  }

  savePatchingClient(client: PatchingClient): Observable<PatchingClient> {
    let url =  environment.apiWinPatch + "/clients/" + client.deviceNumber;
    let bodyString = JSON.stringify(client); // Stringify payload
    return this.http.put<PatchingClient>(url, bodyString, {headers:this.opts.headers});
  }

  performPatchingClientAction(client: PatchingClient, action: string): Observable<PatchingClient> {
    let url =  environment.apiWinPatch + "/clients/" + client.deviceNumber + "?action=" + action;
    return this.http.post<PatchingClient>(url, null, {headers:this.opts.headers});
  }

//Missing Patches
  getMissingPatches(deviceNumber): Observable<MissingPatchData[]> {
    let url = environment.apiWinPatch  + "/clients/" + deviceNumber + "/patches/missing";
    return this.http.get<MissingPatchData[]>(url);
  }

  getMissingPatchDetailByURL(url): Observable<MissingPatchData> {
    return this.http.get<MissingPatchData>(url);
  }  

  findPatches(deviceNumber,fromDate, toDate, includeStates, excludeStates): Observable<ApiCollection> {
    let url = environment.apiWinPatch  + "/clients/" + deviceNumber + "/patches";

    let qs = '';
    if(fromDate) {qs += 'from=' + fromDate + '&';}
    if(toDate) {qs += 'to=' + toDate + '&';}
    if(includeStates) {qs += 'includeStates=' + includeStates + '&';}
    if(excludeStates) {qs += 'excludeStates=' + excludeStates;}
    if (qs.endsWith('&')) { qs = qs.slice(0,-1);}

    if (qs != '')
    {
      url += '?' + qs;
    }
    
    return this.http.get<ApiCollection>(url);
  }

  // findPatchesWithResponseObject(deviceNumber,fromDate, toDate, includeStates, excludeStates): Observable<HttpResponse<ApiCollection>> {
  //   let url = environment.apiWinPatch  + "/clients/" + deviceNumber + "/patches";

  //   let qs = '';
  //   if(fromDate) {qs += 'from=' + fromDate + '&';}
  //   if(toDate) {qs += 'to=' + toDate + '&';}
  //   if(includeStates) {qs += 'includeStates=' + includeStates + '&';}
  //   if(excludeStates) {qs += 'excludeStates=' + excludeStates;}
  //   if (qs.endsWith('&')) { qs = qs.slice(0,-1);}

  //   if (qs != '')
  //   {
  //     url += '?' + qs;
  //   }
    
  //   return this.http.get<ApiCollection>(url, {observe: 'response'});
  // }

  getPatchDetailByURL(url): Observable<PatchStatus> {
    console.log("getPatchDetailByURL: " + url);
    return this.http.get<PatchStatus>(url);
  }



//Ticket Generator
  getTicketGeneratorConfig(): Observable<TicketGeneratorConfiguration> {
    return this.http.get<TicketGeneratorConfiguration>(this.ticketGeneratorURL);
  }

  saveTicketGeneratorConfig(config: TicketGeneratorConfiguration) {
    let url = this.ticketGeneratorURL;
    let bodyString = JSON.stringify(config); // Stringify payload
    
    return this.http.put(this.ticketGeneratorURL,bodyString,{headers:this.opts.headers});
  }

  getTicketGeneratorPreview(acct:number): Observable<string[]> {
    let url = this.ticketGeneratorURL + "/preview/" + acct;
    return this.http.get<string[]>(url);
  }

  getTicketGeneratorHistory(acct:number, runid: string): Observable<ApiCollection> {

    let url = this.ticketGeneratorURL + "/history?runid=" + runid

    // if (acct) {this.opts.params.set('account', acct.toString());}
    // if (runid) {this.opts.params.set('runid', runid);}

    //url += (acct == null)? "" : "account=" + acct + "&";
    //url += (runid == null)? "" : "runid=" + runid;
    //return this.http.get<ApiCollection>(url, this.opts);
    return this.http.get<ApiCollection>(url, {headers:this.opts.headers});
  }

  getTicketGeneratorHistoryURL(url:string): Observable<PatchingTicketHistory> {
    return this.http.get<PatchingTicketHistory>(url);
  }

  updateTicketGeneratorHistory(ticket: string, updated:boolean):Observable<Response> {
    let url: string;

    if (ticket.length > 12){
      url = ticket;
    }
    else{
      url = this.ticketGeneratorURL + '/history/' + ticket;
    }
    
    let bodyString = updated; // Stringify payload
    
    return this.http.put<Response>(url,bodyString, {headers:this.opts.headers});
  }

  getTicketGeneratorProgress(runid: string): Observable<number> {
    var url = this.ticketGeneratorURL + '/progress/' + runid
    return this.http.get<number>(url);
  }
}

