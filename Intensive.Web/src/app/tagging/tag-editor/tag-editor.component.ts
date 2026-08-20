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
import { mergeMap } from 'rxjs/operators';


@Component({
  selector: 'app-tag-editor',
  templateUrl: './tag-editor.component.html',
  styleUrls: ['./tag-editor.component.css']
})
export class TagEditorComponent implements OnInit {

  
  dlgTitle: string = "Account Tag Editor";
  showForm:boolean;
  componentHeight: number;
  tagListHeight: number;
  progressBarDialog: ProgressBarDialog;
  errorDialog: ErrorDialog;
  confirmationDialog: ConfirmationDialog;
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;

  account: AccountData;
  privateTags: Array<Tag>; //all private tags from the db
  tagname:string;

  constructor(private router: Router, 
              private route: ActivatedRoute,
              private cache: CachingService,
              private tagging: TaggingService,
              private dlgConfirmation: MatDialog,
              private dlgProgressBar: MatDialog,
              private dlgError: MatDialog) {

    this.showForm = true;
    this.componentHeight = window.innerHeight - 85;
    this.tagListHeight = window.innerHeight - 450;

    this.privateTags = new Array<Tag>();
    this.progressBarDialog = new ProgressBarDialog(this.dlgProgressBar);
    this.errorDialog = new ErrorDialog(this.dlgError);
    this.confirmationDialog = new ConfirmationDialog(this.dlgConfirmation);

    this.account = this.cache.account;
    this.cache.showAccount(); //show the account in the banner

    this.tagname = '';
                
  }

  ngOnInit() {
    //build server list
    this.account = this.cache.account;
    this.progressBarDialog.open(this.dlgTitle, "indeterminate");
    this.progressBarDialog.updateProgress(0,"Loading Private Account tags....")

    this.BuildTagsList();
  }

  BuildTagsList(){
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
            if (t.account = this.account.number){
              this.privateTags.push(t);
            }
          },
          error => {
            this.errorDialog.showError(this.dlgTitle, error,"","error");
          },
          () => { 
            this.sortPrivateTags();
            this.progressBarDialog.close();
          }

        );
  }


  //remove from the custom account chip list
  removePrivateChip(tag){
    this.confirmationDialog.open(this.dlgTitle,
      "You are about to delete this tag from the list of private account tags.  Doing so will also remove the tag from ALL servers in this account that have this tag currently assigned",
      "Do you still want to delete this tag?");

    this.confirmationDialog.afterClosed()
      .subscribe(
          proceed => {
            if (proceed){
              //this.deleteTag(tag);
              this.deleteTagFromAssignedServers(tag)
            }
          },
          error => {
              this.errorDialog.showError(this.dlgTitle, error,"","error");
          }
        );
  }

  createNewTag(){
    //validation
    if (this.newTagIsValid()){
      let tag:Tag = new Tag();

      tag.account = this.account.number;
      tag.tagName = this.tagname;

      this.createTag(tag);
    }
  }

  newTagIsValid():boolean{

    if (this.tagname.length == 0){
      this.errorDialog.open(this.dlgTitle, "Enter a tag tp be added","","error");
      return false;
    }

    if (this.tagname.length > 15){
      this.errorDialog.open(this.dlgTitle, "Tags must be 15 characters or less","","error");
      return false;
    }

    //check for duplicate - case-insensitive
    var exists = this.privateTags.some( t => t.tagName.toLowerCase() == this.tagname.toLowerCase())
    if (exists) {
      this.errorDialog.open(this.dlgTitle, "This tag already exists in the list of account tags","","error");
      return false;
    }

    return true;
  }

  //misc helper function
  sortPrivateTags(){
    this.privateTags.sort( (a,b) => {
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


  deleteTagFromDB(tag:Tag){
    this.tagging.deletePrivateTag(this.account.number,tag)
      .subscribe(
        () => {
        },
        error => {
          this.errorDialog.showError(this.dlgTitle, error,"","error");
        }
      );
  }

  deleteTagFromAssignedServers(tag:Tag){
    //find servers that have this tag id in its list of tags
    let assignedServers:Array<ServerData> = this.account.servers.filter(s => s.tags.findIndex(t=> t.id == tag.id) > -1);
    if (assignedServers.length > 0){
      this.totalItems = assignedServers.length;
      this.itemsComplete = 0;
      this.progressBarDialog.open(this.dlgTitle, "determinate");
      this.progressBarDialog.updateProgress(0,"removing tag from server(s)...")
  

      from(assignedServers) //foreach server with a checkmark by it
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
                this.deleteTagFromCachedServers(assignedServers, tag);

                this.removeTagFromList(this.privateTags,tag);
                this.sortPrivateTags();
                this.deleteTagFromDB(tag);
                this.progressBarDialog.close();
              }
            }
          );
    }//else checkedservers.length == 0
  }

  deleteTagFromCachedServers(assignedServers:Array<ServerData>, tag:Tag){
    assignedServers.forEach( (cs,idx,arr) => {
      var i = this.account.servers.findIndex(s=> s.deviceNumber == cs.deviceNumber);
      var k = this.account.servers[i].tags.findIndex(t => t.id == tag.id);
      this.account.servers[i].tags.splice(k,1); //remove from tag list

      if (idx == assignedServers.length - 1){
        this.cache.account = this.account;
      }
    });
  }

  createTag(tag:Tag){
    this.tagging.addPrivateTag(this.account.number,tag)
      .subscribe(
        () => {
          this.privateTags.push(tag);
          this.sortPrivateTags();
          this.tagname = '';
        },
        error => {
          this.errorDialog.showError(this.dlgTitle, error,"","error");
        }
      );
  }

}


