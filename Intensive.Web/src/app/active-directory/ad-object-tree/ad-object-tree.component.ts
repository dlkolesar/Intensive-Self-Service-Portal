import { NestedTreeControl } from '@angular/cdk/tree';
import { SelectionModel } from '@angular/cdk/collections';
import { Component, Injectable, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { BehaviorSubject, from, forkJoin, of } from 'rxjs';
import { mergeMap, merge } from 'rxjs/operators';
import { Subject  }    from 'rxjs';
import { Observable } from 'rxjs';
import { AdObject, AdContainer } from '../models'
import { ActiveDirectoryService } from '../active-directory.service';

import { CachingService } from '../../lib/caching/caching.service';
import { ProgressBarDialog } from '../../lib/progress-bar-dialog';
import { ErrorDialog } from '../../lib/error-dialog';
import { ApiCollection } from '../../lib/shared-data';




@Component({
  selector: 'ss-ad-object-tree',
  templateUrl: './ad-object-tree.component.html',
  styleUrls: ['./ad-object-tree.component.css']
})
export class AdObjectTreeComponent implements OnInit {

  @Input() domain: string;
  @Input() account: number;
  @Input() multiple: boolean = false;
  @Input() expandAll: boolean = false;
  @Input() showQuickSelect: boolean = false;
  
  @Output() selectionChange = new EventEmitter<any>();
  @Output() afterLoaded = new EventEmitter<any>();

  //@Input() baseDN: string; //???

  tree: TreeNode[];
  itemsComplete: number;
  totalItems: number;
  pctComplete: number;
  componentHeight: number;
  
  //filters applied
  showGroups: boolean;
  showUsers: boolean;
  showComputers: boolean;

  nestedTreeControl: NestedTreeControl<TreeNode>;
  nestedDataSource: MatTreeNestedDataSource<TreeNode>;
  checklistSelection = new SelectionModel<TreeNode>(true /* multiple */);

  constructor(private ad: ActiveDirectoryService) { 
    console.log("TREE:constructor");
    this.nestedTreeControl = new NestedTreeControl<TreeNode>(this._getChildren);
    this.nestedDataSource = new MatTreeNestedDataSource();
    this.itemsComplete = 0;
    this.totalItems = 0;
    this.pctComplete = 0;
    this.componentHeight = window.innerHeight - 120;

    this.showGroups = false;
    this.showUsers = false;
    this.showComputers = false;
  }
  
  hasNestedChild = (_: number, nodeData: TreeNode) => nodeData.children.length>0;

  private _getChildren = (node: TreeNode) => node.children;

  ngOnInit() {
    console.log("TREE:Init");
    this.tree = new Array<TreeNode>();
    
    this.FindContainers(this.domain, this.account);
    this.nestedDataSource.data = this.tree;
    this.checklistSelection.changed
      .subscribe(
        chg => {
          console.log(chg);
          console.log(chg.source.selected);
          //emit "selected" event (chg.source.selected)
        },
        err => {
          console.log(err);
        }
      );
  }

  
  toggleGroups(e){
    this.nestedDataSource.data.forEach( 
      (dom, i, arr) => {
          this.nestedTreeControl.getDescendants(dom)
              .filter( (kid, j, lst) => kid.item.isGroup())
              .forEach( (child, i, arr) => {
                  e.source._checked ? this.checklistSelection.select(child) 
                                    : this.checklistSelection.deselect(child);
                  this.selectionChange.emit(this.checklistSelection.selected);
              })  //foreach descendant
    });//foreach dom
    
  }

  toggleUsers(e){
    this.nestedDataSource.data.forEach( 
      (dom, i, arr) => {
          this.nestedTreeControl.getDescendants(dom)
              .filter( (kid, j, lst) => kid.item.isUser())
              .forEach( (child, i, arr) => {
                  e.source._checked ? this.checklistSelection.select(child) 
                                    : this.checklistSelection.deselect(child);
                  this.selectionChange.emit(this.checklistSelection.selected);
              })  //foreach descendant
    });//foreach dom
  }

  toggleComputers(e){
    this.nestedDataSource.data.forEach( 
      (dom, i, arr) => {
          this.nestedTreeControl.getDescendants(dom)
              .filter( (kid, j, lst) => kid.item.isComputer())
              .forEach( (child, i, arr) => {
                  e.source._checked ? this.checklistSelection.select(child) 
                                    : this.checklistSelection.deselect(child);
                  this.selectionChange.emit(this.checklistSelection.selected);
              })  //foreach descendant
    });//foreach dom
  }
  
  
  /** Whether all the descendants of the node are selected */
  descendantsAllSelected(node: TreeNode): boolean {
    const descendants = this.nestedTreeControl.getDescendants(node);
    return descendants.every(child => this.checklistSelection.isSelected(child));
  }

  /** Whether part of the descendants are selected */
  descendantsPartiallySelected(node: TreeNode): boolean {
    const descendants = this.nestedTreeControl.getDescendants(node);
    const result = descendants.some(child => this.checklistSelection.isSelected(child));
    return result && !this.descendantsAllSelected(node);
  }

  /** Toggle the to-do item selection. Select/deselect all the descendants node */
  toggle(node: TreeNode): void {
    this.checklistSelection.toggle(node);
    const descendants = this.nestedTreeControl.getDescendants(node);
    this.checklistSelection.isSelected(node)
      ? this.checklistSelection.select(...descendants)
      : this.checklistSelection.deselect(...descendants);
    
    this.selectionChange.emit(this.checklistSelection.selected);
  }

  FindContainers(dom: string, acct: number){
    let domNode: TreeNode;  //node for the domain

    var filterOU = '(|(objectclass=organizationalunit)(objectclass=organizationalunit))';
    var filterName = '(name=' + acct + ')';
    var filter = '(&(' + filterOU + ')(' + filterName + '))';
    this.ad.FindObjects(dom, filter) //returns apiCollection
        .subscribe(
          results => {
            this.totalItems = results.count;
            results.resources.forEach(
              (url, i, arr) => {
                domNode = this.CreateDomainNode(url);
                this.BuildAccountTree(url, domNode);
                // this.tree.push(domNode);
            });
          },
          err => {console.log(err)},
        );
  }

  BuildAccountTree(url: string, domNode: TreeNode){
    let acctNode: TreeNode; //node for the account OU

    this.ad.GetContainerURL(url)
      .subscribe(
        ou => {
          // eventho the ou value returned is a AdContainer,
          // the object does not have the methods attached to it,
          // only the properties -- it's a weird JS thing that I don't
          // fully understand
          // There is probably a better/more efficient way to convert the 
          // ou object to an AdContainer that has all the protoype 
          // methods, but this is my solution for now.....

          // create a new AdContainer (with prototype methods)
          // and copy all properties from the ou object 
          acctNode = new TreeNode();
          var custOU = new AdContainer();
          custOU.attributes = ou.attributes;
          custOU.classList = ou.classList;
          custOU.displayName = ou.displayName;
          custOU.dn = ou.dn;
          custOU.name = ou.name;
          custOU.childObjects = ou.childObjects
          acctNode.item = custOU;

          this.LoadChildObjects(acctNode);

          //add the acct OU to the domain tree node
          domNode.children.push(acctNode); 

          //now add the completed domain node to the tree
          this.tree.push(domNode);

          this.nestedDataSource.data = this.tree;

          this.pctComplete = Math.floor((++this.itemsComplete/this.totalItems) * 100);
          console.log('items: ' + this.itemsComplete + '  Total: ' + this.totalItems);

          this.nestedTreeControl.dataNodes = this.tree;
          if (this.expandAll) {
            this.nestedTreeControl.expandAll();
          }
          this.afterLoaded.emit(this.tree);
        },
        err => {console.log(err)},
        () => {}

      );
  }
  
  CreateDomainNode(url:string) : TreeNode{
    let node : TreeNode;
    var domName = this.getDomainName(url);
    var o = new AdObject();
    o.attributes = [];
    o.classList = ["top", "domain"];
    o.displayName = domName.toUpperCase();
    o.name = domName.toLowerCase();
    o.dn = "";

    
    node = new TreeNode();
    node.item = o;
    node.children = new Array<TreeNode>();
    return node;
  }


/****************************************
*****************************************
* 
*  Recursive function
* 
******************************************
*****************************************/
  LoadChildObjects(parent: TreeNode){
    let child: TreeNode;
    let ucg: AdObject;
    let ou: AdContainer;

    parent.children = new Array<TreeNode>();

    if (parent.item["childObjects"]){
      parent.item["childObjects"].forEach( (obj:AdObject|AdContainer, index, arr) => {
        let child = new TreeNode();

        let ugc = new AdObject();
        ugc.classList = obj.classList;
        ugc.displayName = obj.displayName;
        
        //ignore anything that ends with a $
        //  $ on the end indicates a "hidden" object
        if (!ugc.displayName.endsWith('$')){ 
          if (ugc.isContainer()){
            let ou = new AdContainer();
            ou.attributes = obj.attributes;
            ou.classList = obj.classList;
            ou.displayName = obj.displayName;
            ou.dn = obj.dn;
            ou.name = obj.name;
            ou.childObjects = obj["childObjects"];
            child.item = ou;
            this.LoadChildObjects(child); //Recursive call
          }
          else{
            ugc.attributes = obj.attributes;
            ugc.dn = obj.dn;
            ugc.name = obj.name;
            child.item = ugc;
          }
          parent.children.push(child);
        }
      });
    }
  }
/****************************************
 *****************************************/

  getDomainName(dn: string):string{
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
}

export class TreeNode {
  children: TreeNode[];
  item: AdObject|AdContainer;
  visible: boolean;

  constructor() {
    this.item = null;
    this.children = new Array<TreeNode>();
    this.visible = true;
  }
}

// const BASE_TREE = JSON.stringify([
//   {
//     item: {
//       dn: "DC=globalrs,DC=rack,DC=space", 
//       name:"globalrs.rack.space", 
//       displayName:"GLOBALRS",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=dfw,DC=intensive,DC=int", 
//       name:"dfw.intensive.int", 
//       displayName:"DFW",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=fra,DC=intensive,DC=int", 
//       name:"fra.intensive.int", 
//       displayName:"FRA",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=hkg,DC=intensive,DC=int", 
//       name:"hkg.intensive.int", 
//       displayName:"HKG",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=iad,DC=intensive,DC=int", 
//       name:"iad.intensive.int", 
//       displayName:"IAD",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=lon,DC=intensive,DC=int", 
//       name:"lon.intensive.int", 
//       displayName:"LON",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=ord,DC=intensive,DC=int", 
//       name:"ord.intensive.int", 
//       displayName:"ORD",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   },
//   {
//     item: {
//       dn: "DC=syd,DC=intensive,DC=int", 
//       name:"syd.intensive.int", 
//       displayName:"SYD",
//       classList:["top", "domain","domainDNS"]
//     },
//     children:[]
//   }
// ]);
