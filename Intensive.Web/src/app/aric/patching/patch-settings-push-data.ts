
//data returned by ARIC process "PatchSettingsAudit"
import { PatchSettingsPullData } from './patch-settings-pull-data';

export class PatchSettingsPushData  extends PatchSettingsPullData {
    errorMessage: string[];
    keyExists: boolean;
    path: string;
    value: string;

    keyCreated: boolean;
    keyUpdatad: boolean;
    oldValue: string;
    type: string;
}