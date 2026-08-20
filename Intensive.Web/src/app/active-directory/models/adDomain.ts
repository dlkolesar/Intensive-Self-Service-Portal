

import {AdObject} from './adObject';

export class AdDomain extends AdObject{
    fqdn: string;
    sites: string[];    //names of valid sites within this domain
}