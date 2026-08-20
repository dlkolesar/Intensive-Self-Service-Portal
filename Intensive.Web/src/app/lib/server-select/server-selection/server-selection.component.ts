import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChange } from '@angular/core';

import { Tag } from '../../../tagging';
import { ServerData } from "../../account";
import { ServerFilterPipe } from '../server-filters/server-filter.pipe';

@Component({
  selector: 'ss-server-selection',
  templateUrl: './server-selection.component.html',
  styleUrls: ['./server-selection.component.css']
})
export class ServerSelectionComponent implements OnInit, OnChanges {

  @Input() servers:ServerData[];
  @Output() checkboxChange = new EventEmitter<ServerData>();
  @Output() serverClick = new EventEmitter<ServerData>();

  filteredServers: ServerData[];
  dcFilter: string[] = [];
  tags: Array<Tag>;
  currSort: string;
  newSort: string;
  matchDC: string[] = [];  //DC selected from the DC filter box
  matchName: string = '';  //full/partial name entered in the name filter box
  matchTags: Array<Tag> = new Array<Tag>();  //Tags selected from the Tag filter box

  componentHeight: number = 0;
  
  selectedServer: ServerData = new ServerData(0,'');
  toggleAllServers: boolean;

  constructor(private filter: ServerFilterPipe) {
    this.componentHeight = window.innerHeight - 80;
  }

  ngOnInit() {
    
    // this.servers.sort( //sort the server list
    //   (a,b) =>{
    //     if (a.name > b.name) {return 1;}
    //     if (a.name < b.name) {return -1;}
    //     return 0;
    //   }
    // );
    
    // this.servers.forEach(s =>{ //then find all the unique DCs for filtering
    //   if (this.dcFilter.indexOf(s.dataCenter) == -1){
    //     this.dcFilter.push(s.dataCenter);
    //   }
    // });

    // this.filteredServers = this.servers;

    // this.tags = new Array<Tag>();
    // this.Load();

  }
  ngOnChanges(changes: {[propKey: string]: SimpleChange}){
    this.servers = changes.servers.currentValue;

    // console.log("re-applying filters....");
    // console.log("  dc: " + this.matchDC);
    // console.log("name: " + this.matchName);
    // this.filteredServers = this.filter.transform(this.servers,
    //                       {
    //                           dc:this.matchDC,
    //                           name:this.matchName,
    //                           tags: this.matchTags
    //                       })

    //this.tags = new Array<Tag>();
    this.Load();
  }


  Load(){
    // this.servers.sort( //sort the server list
    //   (a,b) =>{
    //     if (a.name > b.name) {return 1;}
    //     if (a.name < b.name) {return -1;}
    //     return 0;
    //   }
    // );
    
    this.servers.forEach(s =>{ //then find all the unique DCs for filtering
      if (this.dcFilter.indexOf(s.dataCenter) == -1){
        this.dcFilter.push(s.dataCenter);
      }

      // s.tags.forEach( (t,idx, arr) =>{
      //   if (this.tags.findIndex( x => x.id == t.id) == -1){
      //     this.tags.push(t);
      //   }
      // });
    });

    

    this.filteredServers = this.servers;
    this.newSort = "number";
    this.currSort = "name";
    this.sortByName();
  }

  toggleAll(e){
    //for each server visible in the list

    this.filteredServers.forEach(d=>{
                            d.checked = e.checked;
                            this.onCheckboxChange(d);
                          });

    // if (e.checked){ //check all visible servers
    //     this.servers.filter(s=> s.visible && !s.checked).forEach(d=>{
    //         d.checked = e.source._checked;
    //     });
    // }
    // else{ //uncheck all visible/checked servers
    //   this.servers.filter(s=> s.visible && s.checked).forEach(d=>{
    //       d.checked = e.source._checked;
    //   });
    // }
    // this.onCheckboxChanged(null);
  }
  onClick(svr){
    this.serverClick.emit(svr);
  }
  onCheckboxChange(svr){
    
    this.checkboxChange.emit(svr);
  }

  onNameFilterChanged(eventData){
    this.matchName = eventData;
    this.filteredServers = this.filter.transform(this.servers,
                                { dc:this.matchDC,
                                  name:this.matchName,
                                  tags: this.matchTags
                                })

  }

  onDCFilterChanged(eventData){
    this.matchDC = eventData;
    this.filteredServers = this.filter.transform(this.servers,
                                { dc:this.matchDC,
                                  name:this.matchName,
                                  tags: this.matchTags
                                })
  }
  
  onTagFilterChanged(eventData: Array<Tag>){
    this.matchTags = eventData;
    this.filteredServers = this.filter.transform(this.servers,
                                { dc:this.matchDC,
                                  name:this.matchName,
                                  tags: this.matchTags
                                })
  }

  onManageTagsClick(){
    
  }


  ChangeSort(){
    switch (this.newSort){
      case "name": {
            this.sortByName();
            this.currSort = "name";
            this.newSort = "number";
            break;
      }
      case "number": {
            this.sortByDeviceNumber();
            this.currSort = "number";
            this.newSort = "name";
            break;
      }
    }//end switch
  }

  sortByDeviceNumber(){
    this.filteredServers.sort( //sort the server list
      (a,b) =>{
        if (a.deviceNumber > b.deviceNumber) {return 1;}
        if (a.deviceNumber < b.deviceNumber) {return -1;}
        return 0;
      });
  }

  sortByName(){
    this.filteredServers.sort( //sort the server list
      (a,b) =>{
        if (a.name > b.name) {return 1;}
        if (a.name < b.name) {return -1;}
        return 0;
      });
  }

}
