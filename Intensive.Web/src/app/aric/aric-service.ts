import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

import { environment } from '../../environments/environment';
import { EventPayload  }  from './event-payload';
import { AricJob } from './aric-job';
import { AricProcess } from './aric-process';
import { ApiCollection } from '../lib/shared-data';
import { AricTimetable, AricTimetableData  } from './aric-timetable-parameters';

@Injectable()
export class AricService {

  //aricEventsAPI: string = "https://automation.api.rackspacecloud.com/internal/events";
  aricJobAPI: string = environment.apiAric + "/jobs";
  aricProcessAPI: string =  environment.apiAric + "/processes";
  aricTimetableAPI: string =  environment.apiAric + "/schedules";
  
  private opts: {
    headers: HttpHeaders,
    params: HttpParams
  };

  constructor (private http: HttpClient) { 
    this.opts = {
      headers: new HttpHeaders(),
      params: new HttpParams()

    };
  }


//Jobs   
  startJob(systemid:number, payload:EventPayload, token: string): Observable<AricJob> {
    //this.opts.headers.set('X-Auth-Token', token);
    //this.opts.params.set('systemid', systemid.toString());

    //return this.http.post<AricJob>(this.aricJobAPI,payload,this.opts);

    let h = new HttpHeaders().set('X-Auth-Token', token);
    let qs = new HttpParams().set('systemid', systemid.toString());
    return this.http.post<AricJob>(this.aricJobAPI,payload,{headers:h, params:qs});
  }

  findJobs(systemid: number, accountNumber?: number, deviceNumber?: number): Observable<ApiCollection> {
    let qs = new HttpParams().set('systemid', systemid.toString());
    if (accountNumber){ 
      qs = qs.append("accountNumber", accountNumber.toString());
    }
    if (deviceNumber){ 
      qs = qs.append("deviceNumber", deviceNumber.toString());
    }

    return this.http.get<ApiCollection>(this.aricJobAPI, {params: qs});
  }
  

  // getJob(systemid: number, accountNumber?: number, deviceNumber?: number): Observable<ApiCollection> {
  //   let qs = new URLSearchParams();
  //   qs.set("systemid", systemid.toString());
  //   if (accountNumber){ 
  //     qs.set("accountNumber", accountNumber.toString());
  //   }
  //   if (deviceNumber){ 
  //     qs.set("deviceNumber", deviceNumber.toString());
  //   }
  //   let options       = new RequestOptions({ search: qs });
    
  //   return this.http.get(this.aricJobAPI, options)
  //                     .map(this.extractData);
  // }

  getJobByURL(url: string): Observable<AricJob> {
    return this.http.get<AricJob>(url);
  }
  

//Processes   
  findProcesses(systemid:number, name:string): Observable<ApiCollection> {
    let qs = new HttpParams();
    if (systemid){
      qs = qs.append('systemid', systemid.toString());
    }

    if (name){
      qs = qs.append("name", name.toString());
    }
    
    return this.http.get<ApiCollection>(this.aricProcessAPI,{params: qs});
  }

  getProcessByURL(url:string): Observable<AricProcess> {
    return this.http.get<AricProcess>(url)
  }


// //Timetable   
//   createTimetable(payload:AricTimetable, token: string, account: number): Observable<AricTimetableData> {
//     this.opts.headers.set('X-Auth-Token', token);
//     this.opts.params.set('account', account.toString());

//     return this.http.post<AricTimetableData>(this.aricTimetableAPI,payload,this.opts);
//   }

//   updateTimetable(systemid: number, accountNumber?: number, deviceNumber?: number): Observable<ApiCollection> {
//     let qs = new URLSearchParams();
//     qs.set("systemid", systemid.toString());
//     if (accountNumber){ 
//       qs.set("accountNumber", accountNumber.toString());
//     }
//     if (deviceNumber){ 
//       qs.set("deviceNumber", deviceNumber.toString());
//     }
//     let options       = new RequestOptions({ search: qs });
    
//     return this.http.get(this.aricJobAPI, options)
//                       .map(this.extractData);
//   }


}
