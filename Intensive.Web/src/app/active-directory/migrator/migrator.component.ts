import {Component, OnInit} from '@angular/core';
import {
  Router,
  ActivatedRoute
} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material';
import { from, forkJoin } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

import { AdObject, AdContainer, AdMigrationRequest, ADMigrationType } from '../models'
import { ActiveDirectoryService } from '../active-directory.service';
import { AdMigrationOptionsDialogComponent } from '../ad-migration-options-dialog/ad-migration-options-dialog.component';
import { CachingService } from '../../lib/caching/caching.service';
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { ApiCollection } from '../../lib/shared-data';


@Component({
  selector: 'ss-migrator',
  templateUrl: './migrator.component.html',
  styleUrls: ['./migrator.component.css']
})
export class MigratorComponent implements OnInit {

  DLG_TITLE: string = "AD Migration Tool";
  
  componentHeight: number;
  adobject: AdObject = new AdObject();
  sourceObjects: AdObject[];
  migratedObjects: AdObject[];

  selectedObjects: AdObject[];
  selectedUsers: AdObject[];
  selectedGroups: AdObject[];
  selectedComputers: AdObject[];

  showGroupOptions: boolean = false;
  showUserOptions: boolean = false;
  showComputerOptions: boolean = false;
  


  progressBarDialog: ProgressBarDialog;
  errorDialog: ErrorDialog
  optionsDialog: MatDialogRef<AdMigrationOptionsDialogComponent>;
  
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;
  constructor( private router: Router,
              private route: ActivatedRoute,
              private cache: CachingService,
              private dlgProgress: MatDialog,
              private dlgError: MatDialog,
              private dlgOptions: MatDialog,
              private ad: ActiveDirectoryService) {

    console.log("ADMT constructor")                ;
    this.componentHeight = window.innerHeight - 130;
    this.progressBarDialog = new ProgressBarDialog(this.dlgProgress);
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.sourceObjects = new Array<AdObject>();
    this.migratedObjects = new Array<AdObject>();
    this.selectedObjects = new Array<AdObject>();
    
    this.itemsComplete = 0;
    this.totalItems = 0;
    this.cache.showAccount();


    
  }

  ngOnInit() {
    console.log("ADMT Init");
  }

  SelectionChanged(evt){
    //this.selectedObjects = evt;
    //console.log(evt);
    this.selectedObjects = evt.map( 
      (node, i, arr) => { return node.item;}
    );
    //split into selectedUsers/Groups/Computers --- using filter()
    //set showXXXXOptions based on length of selectedXXXXX arrays
    this.selectedUsers = this.selectedObjects.filter( o => o.isUser());
    this.selectedGroups = this.selectedObjects.filter( o => o.isGroup());
    this.selectedComputers= this.selectedObjects.filter( o => o.isComputer());

  }
  
  GetOptions(){
     this.showUserOptions = false;
    this.showGroupOptions = false;
    this.showComputerOptions = false;

    this.showUserOptions = this.selectedUsers.length > 0;
    this.showGroupOptions = this.selectedGroups.length > 0;
    this.showComputerOptions = this.selectedComputers.length > 0;

    //if nothing is selected OR only OU's are selected
    //show an error dialog
    if ( (this.selectedObjects.length == 0) || 
         (!this.showUserOptions && 
          !this.showGroupOptions && 
          !this.showComputerOptions) ){
      this.errorDialog.open(this.DLG_TITLE,"No objects have been selected for migration","", "warning")
    }
    else{ //at least one object has been selected; show the options dialog
      this.optionsDialog = 
            this.dlgOptions.open(AdMigrationOptionsDialogComponent,{
                                    data: {
                                      showUserOptions: this.showUserOptions,
                                      showGroupOptions: this.showGroupOptions,
                                      showComputerOptions: this.showComputerOptions,
                                    }
            });
    
      this.optionsDialog.afterClosed().subscribe(result => {
          console.log("afterClosed()");
          this.MigrateObjects();
      });
    }
}



close(a){
  console.log("closing....")
}

  MigrateObjects(){
    // admt user name1,name2,name3 option1, option2......
    // admt group name1,name2,name3......
    // admt computer name1,name2,name3......

    //generate an array/list of AdMigrationRequest objects
    //post to /<adapi>/admt

    let admtRequests = new Array<AdMigrationRequest>();
    let req:AdMigrationRequest;

    if (this.selectedGroups.length > 0){
      req = new AdMigrationRequest();
      req.account = this.cache.account.number;
      req.migrationType = ADMigrationType.GroupMigration;
      req.objects = this.selectedGroups;
      req.options = '<generated options>' + '<user dialog options>';

      admtRequests.push(req);
    }

    if (this.selectedUsers.length > 0){
      req = new AdMigrationRequest();
      req.account = this.cache.account.number;
      req.migrationType = ADMigrationType.UserMigration;
      req.objects = this.selectedUsers;
      req.options = '<generated options>' + '<user dialog options>';

      admtRequests.push(req);
    }

    

    if (this.selectedComputers.length > 0){
      req = new AdMigrationRequest();
      req.account = this.cache.account.number;
      req.migrationType = ADMigrationType.ComputerMigration;
      req.objects = this.selectedComputers;
      req.options = '<generated options>' + '<user dialog options>';

      admtRequests.push(req);
    }
    
    // this.ad.MigrateObjects('globalrs',admtRequests)
    //   .subscribe(
    //     () => {console.log("success")},
    //     err => {console.log("Error")}
    //   )
  }


}

