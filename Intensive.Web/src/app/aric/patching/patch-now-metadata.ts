
import { environment } from '../../../environments/environment';

export class PatchNowMetadata {
    deviceid: number;
    winpatchurl: string;
    ssousername: string;
    endtime: Date;          //optional. maint window end time
    downloadpatches: boolean;
    installpatches: boolean;
    reboot: boolean;        //reboot server after patching, if required
    forcereboot: boolean;   //force a  reboot after patching
    triggeredby: string;    
    constructor() {
        this.winpatchurl = environment.winPatchCallbackURL;
        this.triggeredby = "portal"; //tells the ARIC process to callback to the winpatch URL when finished.
        this.reboot = false;
        this.forcereboot = false;
        this.endtime = null;
    }
}

