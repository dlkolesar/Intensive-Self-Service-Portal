
import { PatchingClient } from '../models/patching-client';

export class ReportLine {
    statusIcon: string; //name of material design icon to display next to this client
    statusIconColor: string; //the foreground color of the icon, 'red', 'yellow', 'blue'...
    statusMessage: string;
    deviceNumber: number;
    name: string;
    dataCenter: string;
    patchingLevel: string;
    lastContact: Date;
    lastPatchDate: Date;
    nextPatchDate: Date;
    errors: string[];

    constructor (pc: PatchingClient){
        this.statusIcon = pc.statusIcon;
        this.statusIconColor = pc.statusIconColor;
        this.statusMessage = pc.statusMessage;
        this.deviceNumber = pc.deviceNumber;
        this.name = pc.name;
        this.dataCenter = pc.dataCenter;
        
        var patchingLevels = ['None','Basic','Advanced','Manual']
        this.patchingLevel = patchingLevels[pc.patchingLevel];

        this.lastContact = pc.lastContact;
        this.lastPatchDate = pc.lastPatchDate;
        this.nextPatchDate = pc.nextPatchDate;
        this.errors = pc.errors;
    }
 }