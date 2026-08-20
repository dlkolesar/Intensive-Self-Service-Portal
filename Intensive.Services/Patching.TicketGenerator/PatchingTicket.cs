using System.Text;
using Intensive.Data.SSDatabase;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.CTKAPIWrapper.Exceptions;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class PatchingTicket
    {
        const int TICKET_SOURCE = 3;    // 3= Racker

        protected string TicketTemplate = string.Empty;
        protected ILogger log;
        protected CTKAPI core = null;
        protected SSDatabaseContext db = null;
        //protected TbPatchingTicketConfig config;

        protected string RunID = DateTime.Now.ToString("yyyyMM");

        public List<int> CoreDeviceList { get; set; }

        public PatchingTicket(ILogger<PatchingTicketGenerator> logger,
                                        SSDatabaseContext dbContext,
                                        CTKAPI coreCTKAPI
                                        )
        {
            
            this.CoreDeviceList = new List<int>();
            this.core = coreCTKAPI;
            this.db = dbContext;
            this.log = logger;
        }
        
        //returns ticket number created
        public virtual string GenerateTicket(COREAccount coreAccount, List<PatchingClient> clients, GeneratorConfig config)
        {
            return string.Empty;
        }

        //returns the preview in text only form
        public  virtual string GeneratePreview(COREAccount coreAccount, List<PatchingClient> clients, GeneratorConfig config)
        {
            return string.Empty;
        }


        public virtual CORETicket CreateTicketData(COREAccount coreAccount, string ticketText)
        {
            return new CORETicket();
        }




        protected string CreateTicketPreview(CORETicket tkt)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendLine("Queue:" + tkt.QueueID);
                sb.AppendLine("Subject:" + tkt.Subject);
 
                switch (tkt.Status)
                {
                    case (int)EnterpriseAmCORETicket.TicketStatus.New: sb.AppendLine("Status: New"); break;

                    case (int)ManagedCORETicket.TicketStatus.ConfirmSolved:
                    case (int)EnterpriseCORETicket.TicketStatus.ConfirmSolved:
                        sb.AppendLine("Status: Confirm Solved");
                        break;
                    default: sb.AppendLine("Status: " + tkt.Status.ToString()); break;
                }
 
                sb.AppendLine("Devices");
                foreach (int d in tkt.ComputerList)
                {
                    sb.AppendLine(d.ToString());
                }
                
                sb.AppendLine("Initial Message:");
                sb.AppendLine(tkt.InitialMessage);

                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw new PreviewFileException($"Error Creating preview", ex);
            }
        }


        protected string CreateCORETicket(CORETicket tkt)
        {
            CTKAction action = new CTKAction();

            //log.LogError($"tkt: {JsonConvert.SerializeObject(tkt)}");

            action.ClassName = "Account.Account";
            action.LoadArgs = tkt.Account;
            action.MethodName = "addTicket";
            action.MethodArguments = new List<object>();
            action.MethodArguments.Add(tkt.QueueID);              //queue id number
            action.MethodArguments.Add(tkt.SubCategory);        //sub category 
            action.MethodArguments.Add(TICKET_SOURCE);          //source
            action.MethodArguments.Add((int)tkt.Severity);      //severity 1 = standard
            action.MethodArguments.Add(tkt.Subject);            //ticket subject
            action.MethodArguments.Add(tkt.InitialMessage.Replace("\"", "'"));    // intitial message
            action.MethodArguments.Add(tkt.ComputerList);       // array of computer id #'s to attache to the ticket
            action.MethodArguments.Add(0);                      // t/f - message is private? 0 == false
            action.MethodArguments.Add(tkt.Recipients);         //recipients - core contact id #'s
            action.MethodArguments.Add(null);                   //assignee
            action.MethodArguments.Add(null);                   //source_contact
            action.MethodArguments.Add(false);                  //is_private_ticket
            action.MethodArguments.Add(false);                  //send_message_text
            action.MethodArguments.Add(tkt.Status);             //status


            //string s = action.ToString();
            CTKResultDictionary results = null;
            try
            {
                string json = action.ToString();
                //log.LogDebug($"Create CORE Ticket: {json}");

                CTKActionResponse resp = core.Submit(action);
                if (resp == null)
                {
                    log.LogError($"response is NULL");
                }
                results = (CTKResultDictionary)resp.Results;
            }
            catch (Exception ex)
            {
                log.LogError($"{ex.Message} thrown from CTKAPI");
                if (ex is CTKHttpException)
                {
                    throw;
                }
                else
                {
                    throw new CoreTicketException("Error Creating CORE Ticket", ex);
                }
                
            }

            return results[0]["load_value"].ToString();


        }


        protected string RenderPatchingClientConfiguration(List<PatchingClient> clients)
        {

            StringBuilder ClientConfig = new StringBuilder();
            this.CoreDeviceList.Clear();

            //log.LogDebug($"Rendering Client Config for Clients: {JsonConvert.SerializeObject(clients)}");
            
            foreach (PatchingClient c in clients)
            {
                this.CoreDeviceList.Add(c.DeviceNumber); 

                ClientConfig.Append(c.Name + " - ");
                if (c.Errors.Count > 0)
                {
                    ClientConfig.AppendLine("Invalid device configuration. Contact support for details.");
                    foreach (string msg in c.Errors)
                    {
                        ClientConfig.AppendLine("   ---> " + msg);
                    }
                }
                else if (c.OptedOut)
                {
                    ClientConfig.AppendLine("Device has opted out of management");
                }
                else if (c.PatchingLevel == PatchingLevels.None)
                {
                    ClientConfig.AppendLine("Windows Update is disabled on this device.");
                }
                else
                {
                    if (c.PatchingLevel == PatchingLevels.Advanced)
                    {
                        ClientConfig.Append("Advanced Patching ");
                        

                        ClientConfig.Append($" - {TranslateToSystemWeekday(Convert.ToInt32(c.AdvancedPatching.DayOfWeek) + 1)}");
                        ClientConfig.Append($" - {c.AdvancedPatching.Hour}:{c.AdvancedPatching.Minute} UTC");
                        switch (c.AdvancedPatching.DayOfMonth)
                        {
                            case "1-7"  : ClientConfig.Append(" - 1st  "); break;
                            case "8-14" : ClientConfig.Append(" - 2nd  "); break;
                            case "15-21": ClientConfig.Append(" - 3rd  "); break;
                            case "22-28": ClientConfig.Append(" - 4th  "); break;
                            case "25-31": ClientConfig.Append(" - Last "); break;
                        }
                    }
                    else  //Basic patching level
                    {
                        try
                        {
                            ClientConfig.Append(TranslateAuOptions(c.AUOptions));
                            if (c.AUOptions == 4)
                            {
                                ClientConfig.Append(" - " + TranslateToSystemWeekday((int)c.ScheduledDay));

                                ClientConfig.Append(" - " + TranslateInstallTime((int)c.ScheduledTime));
                            }
                            ClientConfig.Append(" - " + TranslateReleaseWeek((int)c.ScheduledWeek));
                        }
                        catch (Exception ex)
                        {
                            ClientConfig.Append($" - {ex.Message}");
                        }
                    }//if advanced patching

                    ClientConfig.AppendLine();  //tack on a CRLF
                }
            }//Foreach Computer

            //log.LogDebug($"[Render]this.CoreDeviceList: {this.CoreDeviceList.Count}");

            return ClientConfig.ToString();
            
        }

        protected string MergeConfigWithTemplate(COREAccount coreAccount, string clientConfig, GeneratorConfig config )
        {
            string TicketText = config.TicketTemplate;

            //build the ticket text from the template by replacing the variables
            TicketText = TicketText.Replace("${ae_name}", coreAccount.AM);

            TicketText = TicketText.Replace("${detail_schedule}", clientConfig);
            TicketText = TicketText.Replace("${detail_urls}", $"* http://technet.microsoft.com/en-us/security/bulletin/ms{DateTime.Now.ToString("yy-MMM").ToLower()}");
            TicketText = TicketText.Replace("${detail_weeks}", RenderPatchingWeeks());
            TicketText = TicketText.Replace("${support_team}", coreAccount.SupportTeamName);

            TicketText = TicketText.Replace("${updates_approved}", config.ApprovedUpdates);
            TicketText = TicketText.Replace("${updates_not_approved}", config.DeclinedUpdates);

            return TicketText;
        }


  
        #region Translators
        protected string TranslateToSystemWeekday(int value)
        {
            string[] DayName = new string[] {"Every Day",
                                                "Sunday",
                                                "Monday",
                                                "Tuesday",
                                                "Wednesday",
                                                "Thursday",
                                                "Friday",
                                                "Saturday"
                                            };
            if (value >= 0 && value <= 7)
            {
                return DayName[value];
            }
            else
            {
                throw new TranslationException($"Scheduled Day '{value.ToString()}' should be 0-7");
            }
        }


        protected string TranslateAuOptions(int value)
        {
            switch (value)
            {
                case 2: return "Notify before download";
                case 3: return "Notify before installation";
                case 4: return "Schedule installation";
                case 5: return "User can configure";
                default:
                    throw new TranslationException($"AuOption '{value.ToString()}' should be 2-5");
            }
        }

        protected string TranslateInstallTime(int value)
        {
            if (value >= 0 && value <= 23)
            {
                return new DateTime(1900, 1, 1, value, 0, 0).ToShortTimeString();
            }
            else
            {
                throw new TranslationException($"Scheduled Time '{value.ToString()}' should be 0-23");
            }
        }

   
        protected string TranslateReleaseWeek(int value)
        {
            switch (value)
            {
                case 1: return "ReleaseWeekEarly";
                case 2: return "ReleaseWeekDefault";
                case 3: return "ReleaseWeekDelayed";
                default:
                    throw new TranslationException($"Release Week '{value.ToString()}' should be 1-3");
            }
        }

     
        protected string RenderPatchingWeeks()
        {
            PatchingMonth month = new PatchingMonth();
            string fmt = "Early Week{0}{1}-{2}{0}{0}" +
                        "Default Week{0}{3}-{4}{0}{0}" +
                        "Delayed Week{0}{5}-{6}";

            return string.Format(fmt, "\\n", month.GetWeekStartDate(1).ToString("MMMM d"), month.GetWeekStartDate(1).AddDays(6).ToString("MMMM d"),
                                            month.GetWeekStartDate(2).ToString("MMMM d"), month.GetWeekStartDate(2).AddDays(6).ToString("MMMM d"),
                                            month.GetWeekStartDate(3).ToString("MMMM d"), month.GetWeekStartDate(3).AddDays(6).ToString("MMMM d"));
        }
        #endregion

    }
}
