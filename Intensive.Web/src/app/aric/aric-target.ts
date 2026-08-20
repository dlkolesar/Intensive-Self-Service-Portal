export class AricTarget {
    href: string;
    rel: string;


    constructor(){ }
}

export class AricCloudTarget extends AricTarget {
   
    constructor(dc:string, tenant: number, instance: string){
        super();
        this.href = "https://<CloudDC>.servers.api.rackspacecloud.com/v2/<tenant>/servers/<InstanceID>";
        this.rel = "http://schemas.automation.rackspacecloud.com/targets/device";

    }
}

export class AricDedicatedTarget extends AricTarget {

    constructor(device: number){
        super();
        this.href = "http://core.rackspace.com/py/core/#/device/"+ device;
        this.rel = "http://schemas.automation.rackspacecloud.com/targets/device"
    }
}
