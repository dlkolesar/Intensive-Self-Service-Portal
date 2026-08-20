

export class AdObject{
    dn: string;
    name: string;
    displayName: string;
    classList: string[];
    principalName: string; // <domain>\<samaccountname> OR <domain>\<name>
    domainName: string;
    attributes: object;
    isHidden: boolean;
   
    isDomain():boolean { return this.classList.indexOf('domain') > -1}
    isContainer():boolean { return this.classList.indexOf('organizationalUnit') > -1 || this.classList.indexOf('container') > -1}
    isUser():boolean { return this.classList.indexOf('user') > -1 && this.classList.indexOf('computer') == -1}
    isGroup():boolean { return this.classList.indexOf('group') > -1}
    isComputer():boolean { return this.classList.indexOf('computer') > -1}
    isForeignSecurityPrincipal():boolean { return this.classList.indexOf('isForeignSecurityPrincipal') > -1}
 

    
    // getDomainName():string{
    //     var path = this.dn.split(',');
    //     var part = [];

    //     for (var i=0;i>path.length;i++)
    //     {
    //         part = path[i].split('=');
    //         if (part[0].toLowerCase() == 'dc'){
    //             return part[1];
    //         }
    //     }
    //     return 'UNKNOWN';
    // }
}