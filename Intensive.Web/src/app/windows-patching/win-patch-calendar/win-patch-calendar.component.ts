import { Component, OnInit, Input, Output, OnChanges, EventEmitter} from '@angular/core';
import * as moment from 'moment';
import { PatchingClient } from '../models';
@Component({
  selector: 'ss-win-patch-calendar',
  templateUrl: './win-patch-calendar.component.html',
  styleUrls: ['./win-patch-calendar.component.css']
})
export class WinPatchCalendarComponent implements OnInit {

    @Input() client: PatchingClient;
    @Output() dateSelected = new EventEmitter<PatchDateChangedEvent>()

    patchTue;
    month;
    weeks;
    selected;
    locale;
    date: Date;
    dtEarlyReleaseWeek;   //starting date(Sunday) of the release week
    dtDefaultReleaseWeek; //starting date(Sunday) of the release week
    dtDelayedReleaseWeek; //starting date(Sunday) of the release week


    constructor() {
    
   }



  ngOnInit() {
    // let dt: Date = this.date || new Date(Date.now());
    
    // this.selected = moment(dt).hour(0).minute(0).second(0).millisecond(0);

    // let start = this.selected.clone();
    // this.month = this.selected.clone();
    // start.toLocaleString();
    // start.date(1);
    // this._removeTime(start.day(0)); //start on the first Sunday of the month
    // this._buildMonth(start, this.month);//start on the first Sunday of the month

    // this.InitializeCalendar(moment(new Date(Date.now())));
  }
    
  ngOnChanges(chgs){
    console.log(chgs);
    if (chgs.client){
      this.client = chgs.client.currentValue;
    }

    let dt: Date = this.date || new Date(Date.now());
    
    this.selected = moment(dt).hour(0).minute(0).second(0).millisecond(0);
    this.patchTue = moment(dt).hour(0).minute(0).second(0).millisecond(0);

    let start = this.selected.clone();
    this.month = this.selected.clone();
    start.toLocaleString();
    start.date(1);
    this._removeTime(start.day(0)); //start on the first Sunday of the month
    this._buildMonth(start, this.month);//start on the first Sunday of the month

    this.InitializeCalendar(moment(new Date(Date.now())));
  }
  select(day) {
      this.selected = day.date.clone();  
      this.SelectDate(this.selected);
  };


  next() {
    var next = this.month.clone();
    this._removeTime(next.month(next.month()+1).date(1));

    this.month.month(this.month.month()+1);
    this._buildMonth(next, this.month.date(1));
    this.InitializeCalendar(this.month.date(1));
  };

  previous() {
    var previous = this.month.clone();
    this._removeTime(previous.month(previous.month()-1).date(1));
    this.month.month(this.month.month()-1);
    this._buildMonth(previous, this.month.date(1));
    this.InitializeCalendar(this.month.date(1));
  };

  _removeTime(date) {
    return date.day(0).hour(0).minute(0).second(0).millisecond(0);
  }

  _buildMonth(start, month) {
      this.weeks = [];
      let done = false;
      let date = start.clone();
      let monthIndex = date.month();
      let count = 0;

      while (!done) {
          this.weeks.push({ 
                days: this._buildWeek(date.clone(), month),
                bg:"",
                color:""

            });
          date.add(1, "w");
          //done = count++ > 2 && monthIndex !== date.month();
          done = count++ > 4;
          monthIndex = date.month();
      }
  }

  _buildWeek(date, month) {
      var days = [];
      for (var i = 0; i < 7; i++) {
          days.push({
            //   name: date.format("dd").substring(0, 1),
              name: date.format("d"),
              number: date.date(),
              isCurrentMonth: date.month() === month.month(),
              isToday: date.isSame(new Date(), "day"),
              date: date,
              bg:"",
              color:"",
              selected: false
          });
          date = date.clone();
          date.add(1, "d");
      }
      return days;
  }

  SelectPatchDate(week:number, day:number){
    let dtSelect;
    if (day == 1){ //if Sunday
      day = day + 7 //move to next sunday, since patching weeks start Sat & end on the following Sun
    }
    let d = day - 1;  //momentJS uses 0-6 for days; patching/ui uses 1-7
  
    if (week > 0){
      if ( (this.client.patchingLevel == 1) || (this.client.patchingLevel == 3) ){  //basic or manual patching
        //calculate selected date from the selected Release Week
        switch(week){
          case 1: {dtSelect = this.dtEarlyReleaseWeek.clone(); break;}
          case 2: {dtSelect = this.dtDefaultReleaseWeek.clone(); break;}
          case 3: {dtSelect = this.dtDelayedReleaseWeek.clone(); break;}
        }
      //if (day){
        if (day === 0){
          this.SelectWeek(dtSelect);
        }
        else{
          this.SelectDate(dtSelect.day(d));
        }
      //}
        this.selected = dtSelect
      } // if patchingLevel
    }//if week>0
  }

SelectDate(dt){
    this.weeks.forEach( w => {
        w.days.forEach( d=> {
            d.selected = d.date.isSame(dt,'day')
            if (d.selected){
                var evt = new PatchDateChangedEvent();
                evt.date = dt.toDate();
                evt.day = dt.day() + 1
                evt.releaseWeek = this.determineReleaseWeek(dt);
                this.dateSelected.emit(evt);
            }
        })
    });
}

determineReleaseWeek(dt){  //(dt) is a momentjs object
    let endDt = this.dtDelayedReleaseWeek.clone().add(7, 'days');

    if (dt.isSameOrAfter(this.dtEarlyReleaseWeek,'day')){
      if (dt.isSameOrAfter(this.dtDefaultReleaseWeek,'day')){
        if (dt.isSameOrAfter(this.dtDelayedReleaseWeek,'day')){
          if (dt.isSameOrAfter(endDt,'day')){
            return -1; //not a valid release week
          }
          else{
            return 3; //delayed week
          }
        }
        else{
          return 2; //default week
        }
      } 
      else{
        return 1; //early week
      } 
    }
    else{
        return -1; //not a valid release week
    }
    
}

SelectWeek(startDate){
    let d;
    let endDate = startDate.clone().add(6, 'days');

    this.weeks.forEach( w => {
        w.days.forEach( d=> {
            d.selected = moment(d.date).isBetween(startDate, endDate,'day', '[]');//inclusive between
        })
    });
 }

highlightWeek(startDate, bg, color){
     let d1 = startDate.clone().hour(0).minute(0).second(0).millisecond(0);

     for(var w=0;w<this.weeks.length;w++){
         if (this.weeks[w].days[0].date.isSame(startDate, 'day')){
            this.weeks[w].bg = bg;
            this.weeks[w].color = color;
         }
     }
     this.highlightDateRange(startDate, startDate.clone().add(6,'days'), bg, color);

 }

 highlightDateRange(startDate, endDate, bg, color){
     let d1 = startDate.clone().hour(0).minute(0).second(0).millisecond(0);
     let d2 = endDate.clone().hour(0).minute(0).second(0).millisecond(0);

     let days = d2.diff(d1,'days');
     
     this.highlightDate(d1, bg, color);

     for(var i=0;i<days;i++){
       this.highlightDate(d1.add(1,'days'), bg, color);
     }

 }

 highlightDate(day, bg, color){
    this.weeks.forEach( w => {
        w.days.forEach( d=> {
            if (d.date.isSame(day))
            {
                d.color = color;
                d.bg = bg;
            }
        })
    });

 }



InitializeCalendar(dt){ //dt is a mommentjs object
    this.patchTue = moment(dt).date(12).day("Tuesday");
    //this.calendar.highlightDateRange(patchTue,patchTue,"blue", "white");
  
    let d1 = this.patchTue.clone();
    let d2 = this.patchTue.clone();
    //d1.add(7,'days').day("Sunday");
    //d2.add(7,'days').day("Saturday");
    //this.calendar.highlightDateRange(d1, d2, "lightgreen", ""); 
  
    d1.add(-2,'days');
    d2.add(4,'days');
    //this.calendar.highlightDateRange(d1, d2, "lightblue", ""); 
   
    this.highlightDateRange(this.patchTue,this.patchTue,"blue", "white");
    
    //Early Release Week
    d1.add(8,'days');  //starts on Monday after Patch Tuesday
    d2.add(8,'days');  //ends on the following Sunday
    //this.calendar.highlightDateRange(d1, d2, "lightpink", ""); 
    this.dtEarlyReleaseWeek = d1.clone();
    
  
  //Default Release Week
    d1.add(7,'days');
    d2.add(7,'days');
    //this.calendar.highlightDateRange(d1, d2, "lightgreen", ""); 
    this.dtDefaultReleaseWeek = d1.clone();
    this.highlightDateRange(d1, d2, "lightgreen", ""); 
  
  //Delayed Release Week
    d1.add(7,'days');
    d2.add(7,'days');
    //this.calendar.highlightDateRange(d1, d2, "lightgoldenrodyellow", ""); 
    this.dtDelayedReleaseWeek = d1.clone();
  
    this.highlightWeek(this.dtEarlyReleaseWeek,"lightpink","");
    this.highlightWeek(this.dtDefaultReleaseWeek,"lightgreen","");
    this.highlightWeek(this.dtDelayedReleaseWeek,"lightgoldenrodyellow","");
  
    //select the current patching date, if they contain valid data
    if ( (this.client.scheduledWeek >= 1) && (this.client.scheduledWeek <= 3 ) && 
         (this.client.scheduledDay >= 0) && (this.client.scheduledDay <= 7 )
       )
    {
      this.SelectPatchDate(+this.client.scheduledWeek, +this.client.scheduledDay);//+ to coerce values to be numbers
    }
  
  }
}



export class PatchDateChangedEvent{
    releaseWeek: number;
    day: number;
    date: Date;
}

