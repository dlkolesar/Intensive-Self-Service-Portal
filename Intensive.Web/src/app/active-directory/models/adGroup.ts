
import { AdObject } from './adObject';

export enum AdGroupType {
    SystemGroup =                 1,     //0x00000001
    GlobalGroup =                 2,     //0x00000002
    DomainLocalGroup =            4,     //0x00000004
    UniversalGroup =              8,     //0x00000008
    AuthManBasicGroup=           16,     //0x00000010
    AuthManQueryGroup =          32,     //0x00000020
    SecurityEnabled =   -2147483648     //0x80000000}
}

export class AdGroup extends AdObject{
    groupType: AdGroupType;
  
    isSecurityGroup():boolean{
        return (this.groupType & AdGroupType.SecurityEnabled) == AdGroupType.SecurityEnabled;
    }
}