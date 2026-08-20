
import { environment } from '../../../environments/environment';
export class MetadataRegistryPatching {
    deviceid: number;
    winpatchurl: string;
    base64json: string; //registry keys and optional values
    ssousername: string;
    DisableRestartandAuth: number;
    constructor() {
        this.winpatchurl = environment.winPatchCallbackURL;
        this.DisableRestartandAuth = 0;
    }
}

export class MetadataRegistryPatchingUpdate extends MetadataRegistryPatching {
    disableRestartandAuth: boolean;
   
    constructor() {
        super();
        this.disableRestartandAuth = false;
    }
}

export class RegistryKey{
    Path: string;

    constructor(hklmPath: string){
        this.Path = hklmPath;
    }
}

export class RegistryKeyValue extends RegistryKey{
    property: string;

    constructor(hklmPath: string, val: string){
        super(hklmPath)
        this.property = val;
    }
}

//export class RegistryKeyValueType extends RegistryKeyValue{
    export class RegistryKeyValueType extends RegistryKey{
    Type: string;
    Value: string;

    constructor(hklmPath: string, valType: string, val: string){
        super(hklmPath);
        this.Value = val;
        this.Type = valType;
    }
}


export const DefaultPatchingRegistryKeys_Pull = [
    new RegistryKey("HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\SusClientId"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallDay"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallTime"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\AUOptions"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoRebootWithLoggedOnUsers"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoUpdate"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\UseWUServer"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\WUServer")
]


export const DefaultPatchingRegistryKeyValues = [
    new RegistryKey("HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\SusClientId"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallDay"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallTime"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\AUOptions"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoRebootWithLoggedOnUsers"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoUpdate"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\UseWUServer"),
    new RegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\WUServer")
]



export const ResetClientIDRegistryKeyValues = [
    new RegistryKeyValue("HKLM:\\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate", "AccountDomainSid"),
    new RegistryKeyValue("HKLM:\\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate", "PingID"),    
    new RegistryKeyValue("HKLM:\\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate", "SusClientId"),
    new RegistryKeyValue("HKLM:\\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate", "SusClientIdValidation")
]
