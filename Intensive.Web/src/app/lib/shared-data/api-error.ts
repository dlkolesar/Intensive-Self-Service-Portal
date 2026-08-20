export class ApiError {
    errorCode: number;
    message: string;
    help: string;
    exceptionThrown: Exception;
}


export class Exception{
    ClassName: string;
    Message: string;
    Data: Object;
    InnerException: Exception;
    StackTraceString: string;
    HelpURL: string;
    RemoteStackTraceString: string;
    RemoteStackNumber: string;
    ExceptionMethod: string;
    HResult: number;
    Source: string;
    WatsonBuckets: any;
}