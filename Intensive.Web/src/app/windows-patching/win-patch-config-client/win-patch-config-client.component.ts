import { Component, OnInit, Input, QueryList, ViewChild, OnChanges } from '@angular/core';
import { MatDialog, MatDialogRef, MatDialogConfig } from "@angular/material";
import { FormGroup, FormControl, ValidatorFn, AbstractControl } from '@angular/forms';

import {AricService,
        AricProcess,
        PatchNowMetadata, 
        AricTimetable
      } from '../../aric';

import { PatchingClient, PatchingAdvancedConfig } from '../models'
import { WinPatchCalendarComponent } from '../win-patch-calendar/win-patch-calendar.component';
import { ErrorDialog } from '../../lib/error-dialog';

import * as moment from 'moment';

@Component({
  selector: 'ss-win-patch-config-client',
  templateUrl: './win-patch-config-client.component.html',
  styleUrls: ['./win-patch-config-client.component.css']
})
export class WinPatchConfigClientComponent implements OnInit, OnChanges {

  @Input() client: PatchingClient;
  @ViewChild("patchingCalendar",{static: false}) calendar !: WinPatchCalendarComponent; //look for #patchingCalendar template reference
  

  form: FormGroup;
  //fcAuoptions: FormControl = new FormControl('', [this.validateAuOption()]);

  patchNowArguments: PatchNowMetadata = new PatchNowMetadata();

  public cals: QueryList<WinPatchCalendarComponent>;
  //private calendar: WinPatchCalendarComponent;

  errorDialog: ErrorDialog;
  availableProcesses: AricProcess[];
  selectedProcess: AricProcess;


  advScheduling: AricTimetable
  advSchedTime: string;
  
  constructor( private dlgError: MatDialog,
               private aric: AricService,
              ) {

    this.errorDialog = new ErrorDialog(this.dlgError);

   }

  ngOnInit() {

    this.findPatchingProcesses();

  }

  
  ngOnChanges(chgs)
  {
    if (this.client.patchingLevel == 2){ //if set to Advanced Patching

      if ( (this.client.advancedPatching == null) || (this.client.advancedPatching.id == '00000000-0000-0000-0000-000000000000') ) {
        this.advSchedTime = '00:00';
        //this.patchNowArguments = new PatchNowMetadata();
        this.client.advancedPatching = new PatchingAdvancedConfig();
        this.parseTime(); //parses advSchedTime into client.advancedPatching properties
      }
      else{
        this.advSchedTime = this.client.advancedPatching.hour.padStart(2,'0') + ":" + 
                            this.client.advancedPatching.minute.padStart(2,'0');

        // if (this.client.advancedPatching.arguments.length > 2){                            
        //   var args = JSON.parse(this.client.advancedPatching.arguments[2]);
        //   //metadata is inconsistent.  sometimes the index is "metadata"
        //   // sometimes it's "Metadata"
        //   if (args.Metadata !== undefined){
        //     this.patchNowArguments = args.Metadata;
        //   }
        //   else{
        //     if (args.metadata !== undefined){
        //       this.patchNowArguments = args.metadata;
        //     }
        //   }
        // }
      }// advPatching not null
    }//if level==2
  }
  onDateSelected(e){
    if (e.releaseWeek == -1){
      this.errorDialog.open("Patching Calendar", 
                            "Not a valid patching date; select a date in one of the highlighted rows",
                            "",
                            "error");
    }
    else{
      this.client.scheduledWeek = e.releaseWeek;
    }

    this.client.scheduledDay = e.day;
  }

  ngAfterViewInit(){
    if (this.cals){
      this.cals.changes.subscribe( (lst: QueryList<WinPatchCalendarComponent>) =>
        {
          if (lst.first){
            this.calendar = lst.first;
            this.calendar.InitializeCalendar(moment(new Date(Date.now())));
          }
        });
    }
  }

  onPatchingLevelChange(e){
    switch (+e.value){
      case 0: { //Patching Level = None
                this.client.patchingLevel = 0;
                this.client.noAutoUpdate = true;  //disable AutoUpdate
                break;
              }
      case 1: { //Patching Level = Basic
                this.client.patchingLevel = 1;
                this.client.noAutoUpdate = false;  //enable AutoUpdate
                break;
              }
      case 2: { //Patching Level = Advanced
                this.client.patchingLevel = 2;
                this.client.noAutoUpdate = true; //disable AutoUpdate
                this.client.scheduledWeek = 1;  //set to Early Release week, so patches are "visible" as soon as possible
                this.client.scheduledDay = 1; //set to first day of the week
                this.client.scheduledTime = 0; //set to midnight(00:00hrs)
                break;
              }

      case 3: { //Patching Level = Manual
                this.client.patchingLevel = 3;
                this.client.noAutoUpdate = false; //enable AutoUpdate
                this.client.scheduledWeek = 1;  //set to Early Release week, so patches are "visible" as soon as possible
                this.client.scheduledDay = 1; //set to first day of the week
                this.client.scheduledTime = 0; //set to midnight(00:00hrs)
                break;
              }
    }//switch
   
    this.ngOnChanges(null); //force formatting of adv patching args
  }


  onScheduledWeekChange(e){
    this.client.scheduledWeek = e.value;
    this.calendar.SelectPatchDate(this.client.scheduledWeek, this.client.scheduledDay);
  }

  onScheduledDayChange(e){
    this.client.scheduledDay = e.value;
    this.calendar.SelectPatchDate(this.client.scheduledWeek, this.client.scheduledDay);
  }



  findPatchingProcesses(){
    this.availableProcesses = new Array<AricProcess>();
    
    //this.OpenProgressBar("Advanced Patching","determinate");
    //this.UpdateProgress(0,"Searching for Patching processes...");
    this.aric.findProcesses(14,null)
      .subscribe(results => {
        if (results.count > 0){
          results.resources.forEach( (url, idx, arr) => {
            this.getProcess(url)
          });
        }
    });
  }



  getProcess(url:string){
    this.aric.getProcessByURL(url)
      .subscribe(p => {
          this.availableProcesses.push(p)
      },
      err => { 
        console.log(err);
      },
      () => {

      });
  }

  parseTime(){
    var time = this.advSchedTime.split(':');
    //this.advScheduling.schedule.hour = time[0];
    //this.advScheduling.schedule.minute = time[1];

    this.client.advancedPatching.hour = time[0];
    this.client.advancedPatching.minute = time[1];

    // console.log(this.advScheduling.schedule.minute + ' ' +
    //             this.advScheduling.schedule.hour + ' ' +
    //             this.advScheduling.schedule.day_of_month + ' ' +
    //             '* ' + //month of the year; * = every month
    //             this.advScheduling.schedule.day_of_week)
  }


  
}
