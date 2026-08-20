import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material';
import { environment } from '../../../environments/environment';

import { AuthService } from './auth.service';
import { AuthData } from './auth-data';
import { CachingService } from '../caching';
import { AppConfigService } from '../../lib/shared-data/app-config.service';
import { ErrorDialog } from '../error-dialog/error-dialog.component';


@Injectable()
export class PatchingAdminGuard implements CanActivate {

  errorPopup: ErrorDialog;
  userIsPatchingAdmin: boolean = false;

  winPatchConfig: Object;

  constructor( private auth: AuthService,
               private cache: CachingService,
               private errorDialog: MatDialog,
               private config: AppConfigService
            ) 
{
  this.errorPopup = new ErrorDialog(this.errorDialog);
}
  

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (environment.production){

      this.userIsPatchingAdmin = false;

      if (this.auth.isAuthenticated()){
        this.winPatchConfig = this.config.getConfig("winpatch");
        var winPatchAdmins = this.winPatchConfig["admins"] as Array<string>;
        this.userIsPatchingAdmin = winPatchAdmins.includes(this.cache.authData.sso);
      }
      else
      {
        this.errorPopup.open("Unauthorized", "You are not authorized to access this feature",'', "warning")
        return false;
      }
      return this.userIsPatchingAdmin;
    }
    else{
      //this.errorPopup.open("Unauthorized", "You are not authorized to access this feature",'', "warning")
      return true;
    }
  }
}
