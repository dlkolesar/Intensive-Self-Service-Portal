

export class AricJob {
    eventId: string;
    processName: string;
    accountNumber: number;
    deviceNumber: number;
    state: string;
    message: string;
    returnedData: string;   //JSON string
    submitted: Date;
    started: Date;
    completed: Date;
    systemId: number;
    userId: string;

    constructor() {
        this.eventId = '';
        this.processName = '';
        this.accountNumber = 0;
        this.deviceNumber = 0;
        this.state = '';
        this.message = null;
        this.returnedData = null;
        this.submitted = new Date(Date.now());
        this.started = null;
        this.completed = null;
        this.systemId = 0;
        this.userId = '';
    }

}
