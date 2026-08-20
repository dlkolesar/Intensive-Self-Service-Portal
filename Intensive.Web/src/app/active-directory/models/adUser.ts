

import {AdObject} from './adObject';

export class AdUser extends AdObject{
    userId: string = '';
    firstName: string = '';
    lastName: string = '';
    enabled: boolean = true;
    lockedOut: boolean = false;

    constructor(){
        super();
    }

}
