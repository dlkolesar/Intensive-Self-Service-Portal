import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  
  config: Object = null;

  constructor(private http: HttpClient) { 
    this.init();
  }

  init() {
    this.http.get('/assets/appconfig.json')
      .subscribe(
        cfg => {
          this.config = cfg;
        });
  }

  public getConfig(key: any) {
    return this.config[key];
}

  public load() {
      return new Promise((resolve, reject) => {
              let request:any = null;
              console.log("fetching appconfig.json");
              request = this.http.get('/assets/appconfig.json');

              if (request) {
                  request
                     //.map( res => res.json() )
                      .catch((error: any) => {
                          console.error('Error reading configuration file');
                          console.log(error);
                          resolve(error);
                          return Observable.throw(error.json().error || 'Server error');
                      })
                      .subscribe((responseData) => {
                          this.config = responseData;
                          resolve(true);
                      });
              } else {
                  console.error('Error reading configuration file');
                  resolve('Error reading configuration file');
                  return Observable.throw('Error reading configuration file');
              }
          });
  }
}
