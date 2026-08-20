import { Component, OnInit } from '@angular/core';
// import { Http, 
//         Response, 
//         RequestOptions, 
//         RequestOptionsArgs, 
//         Headers } from '@angular/http';

import { Router, ActivatedRoute, Params } from '@angular/router';
import { CachingService } from '../caching';
import { AuthService } from './auth.service';
import { AuthData } from './auth-data';

//import {Zlib} from 'zlibjs/bin/rawinflate.min.js';
//import pako from 'pako';

@Component({
  selector: 'app-samlauth',
  templateUrl: './samlauth.component.html',
  styleUrls: ['./samlauth.component.css']
})
export class SAMLAuthComponent implements OnInit {

  

  qryString: Params;
  
  constructor(private router: Router,
              private route: ActivatedRoute,
              private cache: CachingService,
              private auth: AuthService) {
                console.log("[samlauth]: start");
              }
  ngOnInit() {
    

    this.route.queryParams.subscribe((p: Params) => {
        this.qryString = p;
        let qs = {};

        Object.keys(p).forEach(k=> qs[k.toLowerCase()] = p[k]);
        this.qryString = qs;

        let token = qs["token"];
        let relay = qs["relaystate"];
        console.log("[samlauth]: token=" + token);
        console.log("[samlauth]: relay=" + relay);

        this.auth.getIdentity(token)
              .subscribe( a => {
                //save auth data and token to cache
                var auth = new AuthData(JSON.stringify(a));
                this.cache.authData = auth;
                if (relay){
                  console.log("[samlauth]: navigating to " + relay);
                  window.location.href = relay;
                  //this.router.navigateByUrl(relay);
                }
              },
              
              err => {console.log(err)}
            );
      });
      
      /* spent 2 whole days trying to get ADFS to Redirect(GET)
      *   back to the web ui /AUTH route and subsequently
      *   to this component.
      * 
      *   however, the SAML XML response is zipped, then base 64-encoded
      *   and passed back via URL querystring.  
      * 
      *   Could not get any JS libraries to unzip the response.
      * 
      *   Got .NET server side ( <apiserver>/Auth endpoint ) to 
      *   unzip it easy enough.  However, the SAML response does not
      *   have the signature embedded in it, ADFS Redirect(GET) returns
      *   the signature in a separate querystring variable.  And, of course,
      *   the Identity SAML endpoint expects the signature to be embedded in
      *   the response.  And I couldn't find enough information to generate
      *   and insert the signature myself -- integrating systems is a bitch!
      * 
      *   So, for now at least, ADFS will POST the SAML Response(which contains
      *   the signature) to the API Server /AUTH endpoint.  The API calls the 
      *   Identity API, passing it the SAML response.  Then a redirect is issued
      *   to route to this component, which then ultimiately redirects AGAIN to 
      *   the final url.
      *   
      *   quite convoluted, I know, but it works
      * 
      *   Hope you find a better, more elagant solution
      */
  }
}
