import {Component, OnInit, Input, Output,  ViewChild, EventEmitter} from '@angular/core';
import { Observable, Subject } from 'rxjs';
import {
  Router,
  ActivatedRoute
} from "@angular/router";

import { MatDialog, MatTableDataSource, MatSort } from '@angular/material';
import { SelectionModel  } from '@angular/cdk/collections';

import { AdObject } from '../models'
import { ActiveDirectoryService } from '../active-directory.service';
import { CachingService } from '../../lib/caching/caching.service';
import { ErrorDialog } from '../../lib/error-dialog';


@Component({
  selector: 'ss-object-check-list',
  templateUrl: './object-check-list.component.html',
  styleUrls: ['./object-check-list.component.css']
})
export class ObjectCheckListComponent implements OnInit {

  @Input() objects: AdObject[];
  @Input() height: number;
  @Output() selected = new EventEmitter<AdObject[]>();

  adobject: AdObject = new AdObject();
  csvFileName: string ="AD Ojbect.csv"
  errorDialog: ErrorDialog;
  displayedColumns: string[] = ['select', 'domain','icon', 'displayName'];
  selection = new SelectionModel<AdObject>(true, []);
  dataSource = new MatTableDataSource<AdObject>(null);
  
//filters
  showGroups: boolean;
  showUsers: boolean;
  showComputers: boolean;

  numSelected: number
  numRows:number;
  numVisibleRows: number;
  

  @ViewChild(MatSort, {static: false}) sort: MatSort;

   constructor( private router: Router,
              private route: ActivatedRoute,
              private cache: CachingService,
              private dlgProgress: MatDialog,
              private dlgError: MatDialog,
              private ad: ActiveDirectoryService) {
      console.log("ObjChkLst: constructor");
      this.errorDialog = new ErrorDialog(this.dlgError);
      this.showGroups = true;
      this.showUsers = true;
      this.showComputers = true;
  }

  ngOnInit() {
    console.log("ObjChkLst: init");
    this.dataSource = new MatTableDataSource<AdObject>(this.objects);

    var icon: string = '';

    this.dataSource.sortingDataAccessor = (item, property) => {

      switch(property) {
        case 'domain': return this.getDomainName(item.dn);
        case 'icon': return this.getObjectCategory(item);
        default: return item[property].toLowerCase();
      }
    };
    this.dataSource.sort = this.sort;

    this.dataSource.filterPredicate = 
      (data, filter) => {
         return ( 
                  (this.showGroups) && this.isGroup(data) ||
                  (this.showUsers) && this.isUser(data) ||
                  (this.showComputers) && this.isComputer(data) 
                )
       };

    this.selection.changed.subscribe(
      chg => {
        this.selected.emit(chg.source.selected);
      });
  }



  applyFilter(evt){
      switch(evt.value.toLowerCase()){
        case "groups": this.showGroups = evt.source._checked; break;
        case "users": this.showUsers = evt.source._checked; break;
        case "computers": this.showComputers = evt.source._checked; break;
      }

      this.dataSource.filter = evt.value.toLowerCase();
      
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
     this.numSelected = this.selection.selected.length;
     this.numRows = this.dataSource.data.length;
     this.numVisibleRows = this.dataSource.filteredData.length;

      return this.numSelected === this.numRows;

     
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
     this.isAllSelected() ?
         this.selection.clear() :
         this.dataSource.filteredData.forEach(row =>  this.selection.select(row));
  }

  getDomainName(dn:string):string{
    var path = dn.split(',');
    var part = [];
  
    for (var i=0;i<path.length;i++)
    {
        part = path[i].split('=');
        if (part[0].toLowerCase() == 'dc'){
            return part[1].toUpperCase();
        }
    }
    return 'UNKNOWN';
  }

  getObjectCategory(obj: AdObject): string{
    if (this.isDomain(obj)) {return 'widgets'} //domain
    if (this.isUser(obj)) {return 'user'}
    if (this.isGroup(obj)) {return 'group'}
    if (this.isComputer(obj)) {return 'computer'}
    if (this.isContainer(obj)) {return 'web_asset'} //list_alt, ballot
    return 'UNKNOWN';
  }
  isDomain(o:AdObject):boolean { return o.classList.indexOf('domain') > -1}
  isContainer(o:AdObject):boolean { return o.classList.indexOf('organizationalUnit') > -1 || o.classList.indexOf('container') > -1}
  isUser(o:AdObject):boolean { return o.classList.indexOf('user') > -1 && o.classList.indexOf('computer') == -1}
  isGroup(o:AdObject):boolean { return o.classList.indexOf('group') > -1}
  isComputer(o:AdObject):boolean { return o.classList.indexOf('computer') > -1}
}


