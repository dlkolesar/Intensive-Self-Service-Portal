import { ServerData } from "../../lib/account";

export class PatchingClient extends ServerData {
   osVersion: string;
   osMajorVersion: number;
   osMinorVersion: number;
   osBuildNumber: number;
   unSupportedOS: boolean;
   targetId: number;
   patchingLevel: number;
   useWUServer: boolean;
   wuServer: string;
   wuStatusServer: string;
   noAutoUpdate: boolean;
   auOptions: number;
   optedOut: boolean;
//status data
   rebootPending: boolean;
   lastPatchDate: Date;
   nextPatchDate: Date;
   lastContact: Date;
   errors: string[];


//Basic Config
   noAutoRebootWithLoggedOnUsers:boolean;
   scheduledWeek: number;
   scheduledDay: number;
   scheduledTime: number

//Advanced Config
   advancedPatching: PatchingAdvancedConfig;

   constructor(number: number, name:string){
        super(number, name);

        this.osVersion = '';
        this.osMajorVersion = 0;
        this.osMinorVersion = 0;
        this.osBuildNumber = 0;
        this.unSupportedOS = false;
        this.targetId = 0;
        this.patchingLevel = 0;
        this.useWUServer= true;
        this.wuServer = '';
        this.wuStatusServer ='';
        this.noAutoUpdate= false;
        this.auOptions = 0;
        this.optedOut = false;
        this.rebootPending = false;
        this.lastPatchDate = null;
        this.nextPatchDate = null;
        this.lastContact = null;
        this.errors = new Array<string>();
        this.noAutoRebootWithLoggedOnUsers = false;
        this.scheduledWeek = 0;
        this.scheduledDay = 0;
        this.scheduledTime = 0
        this.advancedPatching = new PatchingAdvancedConfig();
   }
}

export class PatchingAdvancedConfig
{
    id: string;
    processName: string;
    arguments: PatchNowArguments
    minute: string;
    hour: string;
    dayOfWeek:string;
    dayOfMonth: string;
    monthOfYear: string;

    constructor(){
        this.processName = '';
        this.arguments = new PatchNowArguments();
        this.minute = '';
        this.hour = '';
        this.dayOfWeek = '';
        this.dayOfMonth = '';
        this.monthOfYear = '*';
    }
}

export class PatchNowArguments {
    endTime: Date;          //optional. maint window end time
    downloadPatches: boolean;
    installPatches: boolean;
    reboot: boolean;        //reboot server after patching, if required
    forceReboot: boolean;   //force a  reboot after patching 
    constructor() {
        this.reboot = false;
        this.forceReboot = false;
        this.endTime = null;
        this.downloadPatches = true;
        this.installPatches = true;
    }
}