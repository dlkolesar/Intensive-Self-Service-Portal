
import {AricTarget, AricDedicatedTarget} from './aric-target';

export class EventPayload {
    tenant: number;     //account number
    targets: AricTarget[]   
    name: string;
    //classification: string;
    source: string;
    metadata: any;  //data to be passed to the process?

    constructor (){
        this.targets = [];
    }

}
