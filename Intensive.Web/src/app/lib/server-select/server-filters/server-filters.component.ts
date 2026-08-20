import { Component, 
         OnInit, 
         Input, 
         Output, 
         EventEmitter, 
         OnChanges, 
         SimpleChanges } from '@angular/core';

import { from, forkJoin } from 'rxjs';

import { Tag } from '../../../tagging'        ;

@Component({
  selector: 'ss-server-filters',
  templateUrl: './server-filters.component.html',
  styleUrls: ['./server-filters.component.css']
})
export class ServerFiltersComponent implements OnInit {



  //if false/empty/not present, 
  //the Name Filter box is not shown
  @Input() nameFilter: boolean = false;

  //array of valid DC's to pick from
  //If empty, the DC Filter box is not shown
  @Input() dcFilterList: string[];

  //array of all tags present on all servers
  @Input() tagFilterList: Array<Tag>;


  @Output() onNameFilterChanged = new EventEmitter<string>();
  @Output() onDCFilterChanged = new EventEmitter<string[]>();
  @Output() onTagFilterChanged = new EventEmitter<Tag[]>();
  @Output() onManageTagsClick = new EventEmitter<Tag[]>();
  
  

  nameFilterValue = '';
  dcFilterValue = [];
  tagFiltersSelected: Array<Tag> = new Array<Tag>()
  tagListHeight:number;
  

  //private dcList:string[];  //from device data

  constructor() {
  }

  ngOnInit() {
    //this.dcFilterList.sort();
    //this.sortFilterInputs();
    this.tagListHeight = 300;
  }
  
  ngOnChanges(changes: SimpleChanges){
    //this.dcFilterList.sort();
    //this.sortFilterInputs();
  }

  onNameFilterKeyUp(evt){
    this.nameFilterValue = evt.target.value;
    this.onNameFilterChanged.emit(this.nameFilterValue);
  }

  onDCFilterChange(evt){
    let index = this.dcFilterValue.indexOf(evt.option.value);

    if (evt.option._selected)
    {
        if (index == -1){ this.dcFilterValue.push(evt.option.value)} //add dc if it does not exist
    }
    else{
      if (index > -1 ) { this.dcFilterValue.splice(index,1);}  //remove dc if it exists
    }
    this.onDCFilterChanged.emit(this.dcFilterValue);
  }


  onTagFilterChange(evt){
    let tag:Tag = evt.option.value;

    let index = this.tagFiltersSelected.findIndex( t => t.id == tag.id);

    if (evt.option._selected)
    {
      if (index == -1){ this.tagFiltersSelected.push(tag)} //add dc if it does not exist
    }
    else{
      if (index > -1 ) { this.tagFiltersSelected.splice(index,1);}  //remove dc if it exists
    }
    this.onTagFilterChanged.emit(this.tagFiltersSelected);
  }

  // sortFilterInputs()
  // {
  //   this.dcFilterList.sort();

  //   this.tagFilterList.sort( (a,b) => {
  //     if (a.tagName.toLowerCase() < b.tagName.toLowerCase()) return -1;
  //     if (a.tagName.toLowerCase() > b.tagName.toLowerCase()) return 1;
  //     return 0;
  //   });
  // }

  openTagManager(){
    this.onManageTagsClick.emit();
  }

}



