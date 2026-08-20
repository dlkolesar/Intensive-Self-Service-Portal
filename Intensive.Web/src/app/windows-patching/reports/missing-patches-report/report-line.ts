import { MissingPatchData } from '../../models';

export class ReportLine {
    statusIcon: string; //name of material design icon to display next to this client
    statusIconColor: string; //the foreground color of the icon, 'red', 'yellow', 'blue'...
    statusMessage: string;
    targetId: number;
    deviceNumber: number;
    name: string;
    unSupportedOS: boolean;
    patchLevel: string;
    missingPatches: MissingPatchData[]
 }