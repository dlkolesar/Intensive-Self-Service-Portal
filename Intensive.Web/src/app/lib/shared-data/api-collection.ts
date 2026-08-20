export class ApiCollection{
    count: number;
    resources: string[];

    constructor(){
      this.count = 0;
      this.resources = new Array<string>();
    }
  }
