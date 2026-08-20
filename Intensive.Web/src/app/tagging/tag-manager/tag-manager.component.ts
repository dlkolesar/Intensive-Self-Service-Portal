import { 
  Component, 
  OnInit
} from '@angular/core';

import {
  Router,
  ActivatedRoute
} from "@angular/router";
import { MatDialog } from "@angular/material/dialog";
import { AccountData, ServerData, ServerService } from '../../lib/account';
import { ApiCollection } from '../../lib/shared-data';
import { Tag, TagSummary } from '../models';
import { TaggingService } from '../tagging.service';

import { CachingService } from "../../lib/caching/caching.service";
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { ConfirmationDialog } from '../../lib/confirmation-dialog';

import { from, forkJoin } from 'rxjs';
import { mergeMap, map } from 'rxjs/operators';


@Component({
  selector: 'app-tag-manager',
  templateUrl: './tag-manager.component.html',
  styleUrls: ['./tag-manager.component.scss']
})
export class TagManagerComponent implements OnInit {

  dlgTitle: string = "Tag Manager";
  showForm: boolean;
  componentHeight: number;
  tagListHeight: number;
  progressBarDialog: ProgressBarDialog;
  errorDialog: ErrorDialog;
  confirmationDialog: ConfirmationDialog;
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;

  account: AccountData;
  servers: ServerData[];

  selectedServer: ServerData;
  currentTags: Array<Tag>;

  publicTags: Array<Tag>; // public tags from the DB
  privateTags: Array<Tag>; //all private tags from the db
  privateTagsRemoveable: boolean;

  availablePublicTags: Array<Tag>; //public tags not currently assigned to selected server(s).  i.e. tags that are available to be assigned
  availablePrivateTags: Array<Tag>; //private tags not currently assigned to selected server(s) i.e. tags that are available to be assigned

  constructor(private router: Router, 
              private route: ActivatedRoute,
              private cache: CachingService,
              private tagging: TaggingService,
              private dlgConfirmation: MatDialog,
              private dlgProgressBar: MatDialog,
              private dlgError: MatDialog) {

    this.showForm = true;
    this.componentHeight = window.innerHeight - 85;
    this.tagListHeight = window.innerHeight - 430;

    this.servers = new Array<ServerData>();
    this.currentTags = new Array<Tag>();
    this.publicTags = new Array<Tag>();
    this.availablePublicTags = new Array<Tag>();
    this.privateTags = new Array<Tag>();
    this.availablePrivateTags = new Array<Tag>();
    this.privateTagsRemoveable = false;
    this.progressBarDialog = new ProgressBarDialog(this.dlgProgressBar);
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.confirmationDialog = new ConfirmationDialog(this.dlgConfirmation);

    this.account = this.cache.account;
    this.cache.showAccount(); //show the account in the banner

   
  }

  ngOnInit() {
    //build server list
    this.account = this.cache.account;
    this.servers = this.account.servers;
    this.selectedServer = null;

    this.progressBarDialog.open(this.dlgTitle, "indeterminate");
    this.progressBarDialog.updateProgress(0,"Loading Public and Private tags....")

    

    this.BuildTagsList();
  }

  BuildTagsList(){
    this.tagging.getPublicTags()
      .subscribe(
        a => { 
          this.GetTagData(a);
        },
        error => {this.router.navigate(['/']);},
        () => { 
          
        }
      );
      this.tagging.getPrivateTags(this.account.number)
      .subscribe(
        a => { 
          this.GetTagData(a);
        },
        error => {this.router.navigate(['/']);},
        () => { 
          
        }
      );
  }

  GetTagData(api:ApiCollection){
    from(api.resources) //foreach url in the resources array
      .pipe(
        mergeMap( url => this.tagging.getTagURL(url))
      )
        .subscribe(
          t => { //Tag
            if (t.account == null){
              this.publicTags.push(t);
            }
            else if (t.account = this.account.number){
              this.privateTags.push(t);
            }
          },
          error => {
            this.errorDialog.showError(this.dlgTitle, error,"","error");
          },
          () => { 
            this.availablePublicTags = Array.from(this.publicTags);
            this.sortPublicTags();
            this.progressBarDialog.close();
          }

        );
  }



// Event Handlers
  serverClick(svr){
    this.selectedServer = svr;
    this.servers.filter(s => s.checked).forEach( s => s.checked = false);
    svr.checked = true;
    this.checkboxChange(svr);
  }

  checkboxChange(svr:ServerData){
    var ts: TagSummary;

    let checkedServers:Array<ServerData> = this.servers.filter(s => s.checked);

    if (checkedServers.length == 0){
      this.selectedServer = null;
    }
    this.currentTags = new Array<Tag>();

    if (checkedServers.length == 0){
      this.selectedServer = null;
    }

    if (checkedServers.length == 1){
      this.selectedServer = svr;
    }

    checkedServers.forEach( (s,i,arr) => {
        if (this.currentTags.length == 0){ 
          this.currentTags = Array.from(s.tags);
        }
        else{
          this.currentTags = Array.from(s.tags.filter( t => 
            this.currentTags.findIndex(x => x.tagName.toLowerCase() == t.tagName.toLowerCase()) > -1
          )
          );
        }
        if (i==checkedServers.length - 1){//end of the list?
          this.resetTagLists();
          this.currentTags.forEach(t=> {
            this.removeTagFromList(this.availablePublicTags, t);
            this.removeTagFromList(this.availablePrivateTags, t);
          })
        }
    });


  }

  assignTagToSelectedServers(tag:Tag){
    let checkedServers:Array<ServerData> = this.servers.filter(s => s.checked);

    if (checkedServers.length == 0){
      this.errorDialog.open(this.dlgTitle, "No servers are selected.","","error");
    }
    else{
      this.totalItems = checkedServers.length;
      this.itemsComplete = 0;
      this.progressBarDialog.open(this.dlgTitle, "determinate");
      this.progressBarDialog.updateProgress(0," Assigning tag to server(s)...")
    
      from(checkedServers) //foreach server with a checkmark by it
        .pipe(
          mergeMap( svr =>
            this.tagging.assignTag(this.account.number, svr.deviceNumber, tag)
          ),
        )
          .subscribe(
            s => {
              this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
              this.progressBarDialog.updateProgress(this.pctComplete, "");
            },
            error => {
              this.errorDialog.showError(this.dlgTitle, error, "", "error");
              ++this.itemsComplete;
            },
            () => { 
              if (this.pctComplete >= 100){
                this.currentTags.push(tag);
                if (tag.account == null){
                  this.removeTagFromList(this.availablePublicTags, tag);
                }
                else{
                  this.removeTagFromList(this.availablePrivateTags, tag);
                }
                
                this.addTagToCachedServers(tag);

                //this.servers.filter(s => s.checked).forEach( s => s.checked = false);
                this.progressBarDialog.close();
              }
            }
          );
    }//else checkedservers.length == 0
  }

  addTagToCachedServers(tag:Tag){
    let checkedServers:Array<ServerData> = this.servers.filter(s => s.checked);

    checkedServers.forEach( (cs,idx,arr) => {
      var i = this.servers.findIndex(s=> s.deviceNumber == cs.deviceNumber);
      //trigger angular's detection mechanism by
      //mutating the "servers" array rather than
      //just mutating the data at servers[i]

      var cs = this.servers[i];
      cs.tags.push(tag);

      var s = [...this.servers];
      s[i] = cs;
      this.servers = [...s];

      //this.servers[i].tags.push(tag);
      if (idx == checkedServers.length - 1){
        this.account.servers = this.servers;
        this.cache.account = this.account;
      }
    });
  }
  

  removeTagFromSelectedServers(tag:Tag){
    let checkedServers:Array<ServerData> = this.servers.filter(s => s.checked);
    if (checkedServers.length == 0){
      this.errorDialog.open(this.dlgTitle, "No servers are selected.","","error");
    }
    else{
      this.totalItems = checkedServers.length;
      this.itemsComplete = 0;
      this.progressBarDialog.open(this.dlgTitle, "determinate");
      this.progressBarDialog.updateProgress(0,"removing tag from server(s)...")
  

      from(checkedServers) //foreach server with a checkmark by it
        .pipe(
          mergeMap( svr => this.tagging.removeTagAssignment(this.account.number, svr.deviceNumber, tag))
        )
          .subscribe(
            s => {
              this.pctComplete = Math.floor(((++this.itemsComplete)/this.totalItems)*100);
              this.progressBarDialog.updateProgress(this.pctComplete, "");
            },
            error => {
            this.errorDialog.showError(this.dlgTitle, error, "", "error");
            ++this.itemsComplete;
            },
            () => { 
              
              if (this.pctComplete >= 100){
                if (tag.account == null){ //public tag being removed
                  this.availablePublicTags.push(tag);
                  this.sortPublicTags();
                }
                else{
                  this.availablePrivateTags.push(tag);
                  this.sortPrivateTags();
                }
            
                //remove from the list of current assigned tags
                this.removeTagFromList(this.currentTags, tag);

                this.removeTagFromCachedServers(tag);
                
                //this.servers.filter(s => s.checked).forEach( s => s.checked = false);
                this.progressBarDialog.close();
              }
            }
          );
    }//else checkedservers.length == 0
  }

  removeTagFromCachedServers(tag:Tag){
    let checkedServers:Array<ServerData> = this.servers.filter(s => s.checked);

    checkedServers.forEach( (cs,idx,arr) => {
      var i = this.servers.findIndex(s=> s.deviceNumber == cs.deviceNumber);
      //trigger angular's detection mechanism by
      //mutating the "servers" array rather than
      //just mutating the data at servers[i]

      var cs = this.servers[i];
      var k = cs.tags.findIndex(t => t.id == tag.id);
      cs.tags.splice(k,1);

      var s = [...this.servers];
      s[i] = cs;
      this.servers = [...s];

      //var k = this.servers[i].tags.findIndex(t => t.id == tag.id);
      //this.servers[i].tags.splice(k,1); //remove from tag list

      if (idx == checkedServers.length - 1){
        this.account.servers = this.servers;
        this.cache.account = this.account;
      }
    });
  }
  
  openTagEditor(){
    this.router.navigate(["/", this.account.number, "tags", "editor"]);
  }


  //misc helper function
  resetTagLists(){
    this.availablePublicTags = Array.from(this.publicTags);
    this.sortPublicTags();

    this.availablePrivateTags = Array.from(this.privateTags);
    this.sortPrivateTags();
  }

  sortPublicTags(){
    this.availablePublicTags.sort( (a,b) => {
      if (a.tagName.toLowerCase() < b.tagName.toLowerCase()) return -1;
      if (a.tagName.toLowerCase() > b.tagName.toLowerCase()) return 1;
      return 0;
    });
  }

  sortPrivateTags(){
    this.availablePrivateTags.sort( (a,b) => {
      if (a.tagName.toLowerCase() < b.tagName.toLowerCase()) return -1;
      if (a.tagName.toLowerCase() > b.tagName.toLowerCase()) return 1;
      return 0;
    });
  }

  removeTagFromList(lst:Array<Tag>, tag:Tag){
    var i = lst.findIndex((x => x.tagName.toLowerCase() == tag.tagName.toLowerCase()));
    if (i > -1){ //if it exists
      lst.splice(i,1);  //remove it
    }
  }


  

 
}


