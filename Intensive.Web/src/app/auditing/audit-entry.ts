
export class AuditEntry {
    id:number;
    systemId: number;
    systemName: string;
    deviceNumber: number;
    deviceName: string;
    account: number;
    userId: string;
    action: string;
    detail: string;
    arrDetails: string[]
    timeStamp: Date;
}
