

import {AdObject} from './adObject';

export class AdContainer extends AdObject{
    childObjects: AdObject[];

    constructor(){
        super();
        this.childObjects = [];
    }

}
