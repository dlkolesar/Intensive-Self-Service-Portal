import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

import { AuthService } from './auth.service';

@Injectable()
export class AuthenticatedGuard implements CanActivate {
  constructor( private auth: AuthService ) {}
  
    canActivate(
      next: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      console.log("canActivate running.....");
      if (environment.production){
        if (this.auth.isAuthenticated()){
          return true;
        }
        else{
          //var baseURL = window.location.protocol + '//' + window.location.hostname;
          var baseURL = 'https://' + window.location.hostname;
          this.auth.redirectToADFS(baseURL + state.url);
        }
      }
      else{ //dev environment
        if (this.auth.isAuthenticated()){
          return true;
        }
        else{
          console.log("authData missing from LocalStorage or token has expired");
          return false;
        }
        
      }
    }
}
