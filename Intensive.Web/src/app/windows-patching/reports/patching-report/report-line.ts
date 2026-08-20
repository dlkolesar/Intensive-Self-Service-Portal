import { PatchStatus } from '../../models';

export class ReportLine {
    //targetId: number;
    deviceNumber: number;
    wsusID: string;
    name: string;
    patchingLevel: number;
    unSupportedOS: boolean;
    patches: PatchStatus[];

    constructor (){
        this.patches = new Array<PatchStatus>();
    }
 }