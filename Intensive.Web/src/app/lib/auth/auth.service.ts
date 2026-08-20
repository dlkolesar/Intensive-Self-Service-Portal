
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { CachingService } from '../caching';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {

  constructor(private cache: CachingService, 
              private http: HttpClient) { }
  
  
  
  redirectToADFS(url){
    //requested url must be double encoded for ADFS to correctly 
    //parse and return it
    //var url = window.location.href.slice(0,-1); //url with the last / chopped off

    //var urlEncoded = encodeURIComponent(encodeURIComponent(url));
    var urlEncoded = encodeURIComponent(url);

    var urlRedirect = environment.ADFS + urlEncoded;
    window.location.href = urlRedirect;
  }

  // getCurrentUserSSO(){
  //   var authdata = this.getAuthData();
  //   return authdata["access"]["user"]["id"];
  // }

  isAuthenticated(){
    let auth = this.cache.authData;
    return auth && !auth.TokenIsExpired();
  }


  getIdentity(token): Observable<string> {
    let url = environment.apiCommon + '/auth/' + token
    return this.http.get<string>(url)
  }

  //saml response passed in must be the 
  // un-encrypted,,base-encoded XML data
  //see: https://pages.github.rackspace.com/ServiceAPIContracts/global-auth-keystone-extensions/api-reference/token-operations.html#get-token-by-saml-assertion
  getIdentityFromSAML(saml): Observable<string> {
    let url = environment.apiIdentitySAML
    let body = new HttpParams().set("SAMLResponse", saml);
    let headers = new HttpHeaders().set("Content-Type", "application/x-www-form-urlencoded");

    return this.http.post<string>(url, body.toString(), {headers: headers});
  }
}
