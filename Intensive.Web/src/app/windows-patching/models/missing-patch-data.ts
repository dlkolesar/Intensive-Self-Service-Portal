export class MissingPatchData {
    state: number;  //WSUS 
                    // 1 - Not Needed (i.e. not applicable)
                    // 2 - Needed (but not downloaded yet)
                    // 3 - Downloaded (but not installed yet)
                    // 4 - Installed successfully
                    // 5 - Failed to install
                    // 6 - Installed but Reboot Required
    changeDate: Date;
    patchId: string;   //WSUS GUID of the update
    localId: number;
    title: string; //patch/update name
    requiresReboot: boolean;  //true if patch/update may require a reboot
    severity: string;
    bulletin: string;
    kbArticle: string;
    url: string;
    targetId: number;
}
