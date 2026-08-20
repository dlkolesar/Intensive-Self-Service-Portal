export class PatchStatus {
    wsusId: string;
    patchId: string;   //WSUS GUID of the update
    localId: number;
    title: string; //patch/update name
    requiresReboot: boolean;  //true if patch/update may require a reboot
    severity: string;
    bulletin: string;
    kbArticle: string;
    url: string;
    state: string;                
    stateChangeDate: Date;
}