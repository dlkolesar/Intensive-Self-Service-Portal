import { concat } from "rxjs/operators";

export class AricTimetable{
    name: string;
    task: string;
    schedule: AricTimetableScheduleChron;
    args: string[];
        //  [0] ==> Identity Token
        //  [1] ==> AccountNumber
        //  [2] ==> RBA Event Payload (event-payload.ts)
    tags: string[]; //optional
    run_once: boolean;
// }

// export class AricTimetableScheduleData extends AricTimetableParameters{
    start_time: Date;
    end_time: Date;
    description: string;
    enabled: boolean;
    is_deleted: boolean;
    last_run_at: Date;
    schedule_id: string;
    total_run_count: number;
    modification_timestamp: Date;
    call_back: boolean;
    request_id: string;
    execution_limit: number;
    next_run: Date;

    constructor (){
//         super();
        this.schedule = new AricTimetableScheduleChron();
        this.run_once = false;
    }

    AddArguments(token, account, metadata){
        this.args[0] = token;
        this.args[1] = account;
        this.args[2] = metadata;
    }
} 

export class AricTimetableData {
    data: AricTimetable[];
} 

export class AricTimetableSchedule{
    schedule_type: string;
    constructor (){
    }
} 

export class AricTimetableScheduleChron extends AricTimetableSchedule{
    minute: string;
    hour: string;
    day_of_week: string;
    day_of_month: string;
    month_of_year: string;
    
    constructor (){
        super();
        this.schedule_type = "crontab"
        this.month_of_year = "*";
    }
    
    importCrontab(crontab: string){
        let sched: string[];

        sched = crontab.split(' ');
        this.minute = sched[0]
        this.hour = sched[1];
        this.day_of_month  = sched[2];
        this.month_of_year = sched[3];
        this.day_of_week = sched[4];
    }

    toString(): string{
        let crontab: string = '';
        return crontab.concat(this.minute,' ',
                        this.hour, ' ',
                        this.day_of_month, ' ',
                        this.month_of_year, ' ',
                        this.day_of_week
                        );
    }
} 
