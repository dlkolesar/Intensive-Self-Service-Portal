using System;
using System.Text;
using Newtonsoft.Json;

namespace Intensive.API.Global
{

    public class APIError
    {
       // public string SubSystem { get; set; }   // the name of the internal component that generated the error
        public int ErrorCode { get; set; }      //internal error code that identifies the specific error.Most error codes will be used to generate events in the Windows Event Log on the API server
        public string Message { get; set; }     //a brief error message that can be display for the user
        public string Help { get; set; }        //URL to retrieve the documentation for this error, which will explain the nature of the error in detail, as well as providing troubleshooting and/or resolution steps 

        public Exception ExceptionThrown { get; set; }

        public APIError() { }
        //public APIError(Exception ex, int errorCode)
        //{
        //    //this.SubSystem = Constants.Errors[errorCode].SubSystem;
        //    this.ErrorCode = errorCode;
        //    this.Message = Constants.Errors[errorCode].Message;
        //    this.Help = Constants.Errors[errorCode].Help;
        //    this.ExceptionThrown = ex;
        //}

        public APIError(Exception ex, int errorCode, string msg)
        {
            this.ErrorCode = errorCode;
            this.Message = msg;
            this.Help = string.Empty;
            this.ExceptionThrown = ex;
        }

        public APIError(Exception ex, int errorCode, string msg, string help)
        {
            this.ErrorCode = errorCode;
            this.Message = msg;
            this.Help = help;
            this.ExceptionThrown = ex;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string FormattedException()
        {
            StringBuilder sb = new StringBuilder();
            
            Exception ex = new Exception(this.Message, this.ExceptionThrown);

            sb.AppendLine(ex.ToString());
            foreach (string key in this.ExceptionThrown.Data.Keys)
            {
                if (this.ExceptionThrown.Data[key] == null)
                {
                    sb.AppendLine($"{key} =  NULL");
                }
                else
                {
                    sb.AppendLine($"{key} =  {this.ExceptionThrown.Data[key].ToString()}");
                }
            }
            return sb.ToString();
        }
    }
}
