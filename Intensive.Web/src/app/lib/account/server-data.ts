import { Tag } from '../../tagging/models/tag';

export class ServerData {
    deviceNumber: number;
    wsusid: string;
    nimbusRobotId: string;
    scomAgentId: string;
    antiVirusId: number;
    linuxPatchingId: number;
    name: string;
    account: number;
    dataCenter: string;
    os: string;
    isCluster: boolean;
    isClusterNode: boolean;
    lastRefresh: Date;
    tags: Array<Tag>;

    checked: boolean; //whether this device has its checkbox checked
    statusIcon: string; //name of material design icon to display next to this client
         //"cached" = busy
         //"error" = failed
         //"warning" = warning
         //"cancel" = opted out
         //"check_circle" = OK/success
    statusIconColor: string; //the foreground color of the icon, 'red', 'yellow', 'blue'...
    statusMessage: string; //text to display in the tooltip when hovering over the status icon
    visible: boolean; //set to false to "hide" this server from displayed list


    constructor(number: number, name:string){
        this.deviceNumber = number;
        this.wsusid = null;
        this.nimbusRobotId = null;
        this.scomAgentId = null;
        this.antiVirusId = null;
        this.linuxPatchingId = null;
        this.name = name;
        this.account = 0;
        this.dataCenter = "";
        this.os = "";
        this.isCluster = false;
        this.isClusterNode = false;
        this.lastRefresh = new Date(Date.now());
    
        this.checked = false;
        this.statusIcon = "";
        this.statusIconColor = "";
        this.statusMessage = "";
        this.visible = true;
        this.tags = new Array<Tag>();
    }
}
