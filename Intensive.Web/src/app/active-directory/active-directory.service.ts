import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
//import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, map, retry, mergeMap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

import { AdObject, AdDomain, AdUser, AdGroup, AdContainer,
  AdGeneratedPassword, AdMigrationRequest ,AdCustomerAccess } from './models';
import { ApiCollection,ApiError } from '../lib/shared-data';
import { CachingService } from '../lib/caching';
import { AuthData } from '../lib/auth';

@Injectable()
export class ActiveDirectoryService {

   
  private opts: {
    headers: HttpHeaders,
    params: HttpParams
  };
  private authHeader: HttpHeaders = new HttpHeaders();
  private auth: AuthData;

  constructor (private http: HttpClient, 
               private cache: CachingService) {

    //if (environment.production){
      this.auth = this.cache.authData;
      //this.authHeader.append('X-Auth-Token',auth.access.token.id);

      this.opts = {
        headers: new HttpHeaders(),
        params: new HttpParams()
      };
      
      this.authHeader = new HttpHeaders({'X-Auth-Token':this.auth.token, 'Content-Type':'application/json'});
      //console.log("headers: " + this.opts.headers.keys());
      
    //}
  }
//Domains
  GetAllDomains(): Observable<ApiCollection> {
    let url = environment.apiAD + "/domains";
    return this.http.get<ApiCollection>(url);
  }

  GetDomain(domain: string): Observable<AdDomain> {
    let url = environment.apiAD + "/domains/" + domain;
    return this.http.get<AdDomain>(url);
  }

//generic objects
  FindObjects(domain: string, filter: string, path:string=null): Observable<ApiCollection> {
    let url = environment.apiAD + "/domains/" + domain + "/objects/?filter=" + encodeURIComponent(filter);
    
    if ( (filter) && (filter.length > 0) ){
      this.opts.params.set('filter', filter);
    }

    if ( (path) && (path.length > 0) ){
      this.opts.params.set('path', path);
    }
    
    return this.http.get<ApiCollection>(url, this.opts);
  }
  

  GetObject(domain: string, dn: string, attributes: string): Observable<AdObject> {
    let url = environment.apiAD + "/domains/" + domain + "/objects/?dn=" + dn;
    if ( (attributes) && (attributes.length > 0) ){
      this.opts.params.set('attributes', attributes);
    }
    return this.http.get<AdObject>(url, this.opts);
  }

  GetObjectURL(url: string, attributes?: string): Observable<AdObject> {
    if ( (attributes) && (attributes.length > 0) ){
      this.opts.params.set('attributes', attributes);
    }
    return this.http.get<AdObject>(url, this.opts);
  }

//containers
GetContainer(domain: string, dn: string, attributes: string): Observable<AdContainer> {
  let url = environment.apiAD + "/domains/" + domain + "/containers"
  
  this.opts.params.set('path', dn);
  
  if ( (attributes) && (attributes.length > 0) ){
    this.opts.params.set('attributes', attributes);
  }
  
  return this.http.get<AdContainer>(url, this.opts);
}


GetContainerURL(url: string, attributes?: string): Observable<AdContainer> {
  if ( (attributes) && (attributes.length > 0) ){
    this.opts.params.set('attributes', attributes);
  }
  return this.http.get<AdContainer>(url, this.opts);
}

//users
  GetUser(domain: string, userid: string, attributes:string): Observable<AdUser> {
    let url = environment.apiAD + "/domains/" + domain + "/users/" + userid;
    if ( (attributes) && (attributes.length>0) ){
      url += "?attributes=" + attributes
    }
    return this.http.get<AdUser>(url);
  }

  GetUserURL(url: string): Observable<AdUser> {
    return this.http.get<AdUser>(url);
  }

  FindUsers(domain: string, filter: string): Observable<ApiCollection> {
    
    let url = environment.apiAD + "/domains/" + domain + "/users/?filter=" + encodeURIComponent(filter);
    return this.http.get<ApiCollection>(url);
  }

  GenerateNewPassword(domain:string, userid: string): Observable<AdGeneratedPassword>{
    let url = environment.apiAD + "/domains/" + domain + "/users/" + userid + "/password";
    return this.http.get<AdGeneratedPassword>(url,{headers: this.authHeader});
  }

  UpdateUser(user: AdUser){
    let url = environment.apiAD + "/domains/" +  user.domainName + "/users/" + user.userId;
    return this.http.put(url,user,{headers: this.authHeader});
  }
  

//group Services

  FindGroups(domain: string, filter: string, path:string): Observable<ApiCollection>{
    let url = environment.apiAD + "/domains/" + domain + "/groups";

      if ( (filter) && (filter.length > 0) ){
        //this.opts.params.set('filter', filter);
        url += '?filter=' + encodeURIComponent(filter);
      }
      else {
        //this.opts.params.set('filter','(name=*)');
        url += '?filter=' + encodeURIComponent('(name=*)');
      }

      if ( (path) && (path.length > 0) ){
        //this.opts.params.append('path', path);
        url += '&path=' + path;
      }

      //return this.http.get<AdGroup>(url,{params: this.opts.params});

      return this.http.get<ApiCollection>(url);
  }

  GetGroup(domain: string, name: string, attributes:string): Observable<AdGroup> {
    let url = environment.apiAD + "/domains/" + domain + "/groups/" + name;
    if ( (attributes) && (attributes.length>0) ){
      url += "?attributes=" + attributes
    }
    return this.http.get<AdGroup>(url);
  }

  GetGroupURL(url: string): Observable<AdGroup> {
    return this.http.get<AdGroup>(url);
  }

  GetGroupMembers(domain: string, userList: string[]): Observable<AdObject[]> {
    let url = environment.apiAD + "/domains/" + domain + "/groups/" + name + '/members';
  
    return this.http.get<AdObject[]>(url);
  
  }
  AddGroupMember(domain: string, group: string, userDN:string):Observable<any> {
    let url = environment.apiAD + "/domains/" + domain + "/groups/" + group;
  
    //return this.http.put(url,userDN,{headers: this.authHeader});

    return this.AddGroupMemberByURL(url, userDN);
  }

  AddGroupMemberByURL(grpUrl: string, userDN:string):Observable<any> {
    //let url = grpUrl + '/members';
    //return this.http.put(url,userDN,{headers: this.authHeader});
    let users = new Array<string>();
    users.push(userDN);
    return this.AddGroupMembersByURL(grpUrl, users);
  }

  AddGroupMembersByURL(grpUrl: string, userList:string[]):Observable<any> {
    let url = grpUrl + '/members';
  
    return this.http.post(url,userList,{headers: this.authHeader});
  }

  RemoveGroupMember(domain: string, group: string, userDN:string):Observable<any> {
    let url = environment.apiAD + "/domains/" + domain + "/groups/" + group;
  
    //return this.http.put(url,userDN,{headers: this.authHeader});

    return this.RemoveGroupMemberByURL(url, userDN);
  }

  RemoveGroupMemberByURL(grpUrl: string, userDN:string):Observable<any> {
    //let url = grpUrl + '/members';
    //return this.http.put(url,userDN,{headers: this.authHeader});
    let users = new Array<string>();
    users.push(userDN);
    return this.RemoveGroupMembersByURL(grpUrl, users);
  }

  RemoveGroupMembersByURL(grpUrl: string, userList:string[]):Observable<any> {
    let url = grpUrl + '/members';
  
    //return this.http.delete(url,userList,{headers: this.authHeader});
    //the Angular 6 http.delete method does not accept a body parameter
    //so I had to use the generic request method 
    return this.http.request('delete',url, {body: userList, headers: this.authHeader});
  }

//Customer Access Services
GrantCustomerAccess(userid: string, acct: string):Observable<any>{
  let url = environment.apiAD + "/domains/intensive/users/" + userid + '/customeraccess/';
  return this.http.post(url,acct,{headers: this.authHeader});
}

RevokeCustomerAccess(userid: string, acct: string){
  let url = environment.apiAD + "/domains/intensive/users/" + userid + '/customeraccess/' + acct;
  return this.http.delete(url,{headers: this.authHeader});
}

//ADMT services
  MigrateObjects(domain: string,requests: AdMigrationRequest[]){
    let url = environment.apiAD + "/domains/" + domain + "/admt";
    return this.http.post(url,requests,{headers: this.authHeader});
  }
}