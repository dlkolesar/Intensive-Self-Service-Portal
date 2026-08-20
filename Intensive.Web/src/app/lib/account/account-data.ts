
import { ServerData } from './server-data';

export class AccountData {
    number:number;
    name: string;
    servers: ServerData[];
    serviceLevel: string;   //intensive or managed.  other??
    show: boolean;  //whether the acct#/name is shown in the title bar

    constructor () {
        this.number = 0;
        this.name = '';
        this.servers = new Array<ServerData>();
        this.show = true;
    }

    // PatchingServers(): ServerData[]{
    //     //var tmp = this.servers.filter(s => s.wsusId != null && s.wsusId != '');
    //     return this.servers.filter(s => s.wsusid != null);
    // }
}
