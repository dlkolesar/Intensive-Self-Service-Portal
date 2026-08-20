
export class ReportLine {
    statusIcon: string; //name of material design icon to display next to this client
    statusIconColor: string; //the foreground color of the icon, 'red', 'yellow', 'blue'...
    statusMessage: string;
    deviceNumber: number;
    name: string;
    dataCenter: string;
    patchingLevel: string;
    action: string;
    scheduledWeek: string;
    schedule: string;
    errors: string[];
 }