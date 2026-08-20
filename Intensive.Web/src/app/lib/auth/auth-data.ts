
export class AuthData {
    identityData: object;

    sso: string
    token: string
    tokenExpires: Date;

    TokenIsExpired(){
        let now: Date = new Date(Date.now());
        return this.tokenExpires < now;
    }

    constructor(json: string){
        this.identityData = JSON.parse(json);

        this.sso = this.identityData["access"]["user"]["id"];
        this.token = this.identityData["access"]["token"]["id"];
        this.tokenExpires = new Date(this.identityData["access"]["token"]["expires"]);
    }
}

