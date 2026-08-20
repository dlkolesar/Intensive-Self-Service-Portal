import { Component, OnInit, Input, Output, EventEmitter
 } from '@angular/core';

import { ServerData } from "../../../lib/account";

@Component({
  selector: 'ss-server-list',
  templateUrl: './server-list.component.html',
  styleUrls: ['./server-list.component.css']
})
export class ServerListComponent implements OnInit {

  @Input() servers: ServerData[];

  @Output() serverClick = new EventEmitter<ServerData>();
  @Output() checkboxChange = new EventEmitter<ServerData>();
  
  selectedServer: ServerData;

  componentHeight: number;

  constructor() {
    //console.log("[server-list]:Constructor");
    this.componentHeight = window.innerHeight - 115;
    this.selectedServer = new ServerData(0,'');
  }

  ngOnInit() {
   
   
  }

  onCheckboxChanged(e, svr){
    let index = this.servers.findIndex(d => d.deviceNumber === svr.deviceNumber);
    this.servers[index].checked = e.checked;
    this.checkboxChange.emit(svr);
  }
 
  onServerSelected(e,svr){

    var index;

    //uncheck the current server
    if (this.selectedServer.deviceNumber > 0){
      index = this.servers.findIndex(d => d.deviceNumber === this.selectedServer.deviceNumber);
      this.servers[index].checked = false;
    }

    index = this.servers.findIndex(d => d.deviceNumber === svr.deviceNumber);
    this.servers[index].checked = true;//set the checkbox
    this.selectedServer = this.servers[index];
    this.serverClick.emit(svr);
  }

  standardServerName(name:string){
      return (name.match(/^\d*\-.*/));
  }
  getDisplayName(server:ServerData){
    let displayName: string;

    if (server.name.match(/^\d*\-.*/)) {
        //standard name #####-serverName
        return server.name;
    }
    else{
        //Non-standard name #####-serverName
        return server.deviceNumber.toString() + ': ' + server.name;
    }
    return displayName;
  }

  
}
