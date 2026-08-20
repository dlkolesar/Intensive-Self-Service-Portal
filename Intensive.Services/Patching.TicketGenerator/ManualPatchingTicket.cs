using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.Patching;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class ManualPatchingTicket : PatchingTicket
    {
        public ManualPatchingTicket(ILogger<PatchingTicketGenerator> logger,
                                          SSDatabaseContext dbContext,
                                          CTKAPI coreCTKAPI
                                          ):base(logger, dbContext,coreCTKAPI)
        {

        }

        public override string GenerateTicket(COREAccount coreAccount, List<PatchingClient> clients, GeneratorConfig config)
        {
            string clientConfig = base.RenderPatchingClientConfiguration(clients);
            //log.LogDebug($"coreAccount: {JsonConvert.SerializeObject(coreAccount)}");
            //log.LogDebug($"clients    : {clients.Count}");
            //log.LogDebug($"config     : {JsonConvert.SerializeObject(config)}");

            StringBuilder sb = new StringBuilder(clientConfig);
            sb.Append("\\n");
            sb.Append("You have servers with manual patching configurations.These servers will need to be updated by logging in and initiating the installation.\\n");
            if (!string.IsNullOrEmpty(coreAccount.PatchingInstructions))
            {
                string escString = coreAccount.PatchingInstructions.Replace("<BR>", "\\n");
                escString = escString.Replace("\"", "\\\""); //escape any embedded double-quotes
                escString = escString.Replace("\\", "\\\\");    //escape any embedded backslashes
                escString = escString.Replace("\r\n", "\\n");
                escString = escString.Replace("\n", "\\n");
                escString = escString.Replace("\t", "\\t");
                sb.Append("We have the following patching instructions on file:\\n");
                sb.Append(escString + "\\n");
            }

            clientConfig = sb.ToString();
            string ticketText = base.MergeConfigWithTemplate(coreAccount, clientConfig, config);

            ticketText = ticketText.Replace("\r\n", "\\n");
            ticketText = ticketText.Replace("\n", "\\n");
            ticketText = ticketText.Replace("\t", "\\t");

            CORETicket tktData = CreateTicketData(coreAccount, ticketText);
            string ticketNumber = base.CreateCORETicket(tktData);

            return ticketNumber;
        }

        //returns the preview in text only form
        public override string GeneratePreview(COREAccount coreAccount, List<PatchingClient> clients, GeneratorConfig config)
        {
            string clientConfig = base.RenderPatchingClientConfiguration(clients);
            
            
            StringBuilder sb = new StringBuilder(clientConfig);

            sb.Append("You have servers with manual patching configurations.These servers will need to be updated by logging in and initiating the installation.\\n");
            if (!string.IsNullOrEmpty(coreAccount.PatchingInstructions))
            {
                string escString = coreAccount.PatchingInstructions.Replace("<BR>", "\n");
                escString = escString.Replace("\"", "\\\""); //escape any embedded double-quotes
                escString = escString.Replace("\\", "\\\\");    //escape any embedded backslashes


                sb.Append("We have the following patching instructions on file:\n");
                sb.Append(escString + "\n");
            }

            clientConfig = sb.ToString();

            string ticketText = base.MergeConfigWithTemplate(coreAccount, clientConfig, config);
            CORETicket tktData = CreateTicketData(coreAccount, ticketText);
            string preview = base.CreateTicketPreview(tktData);

            return preview;
        }



        public override CORETicket CreateTicketData(COREAccount coreAccount, string ticketText)
        {
            CORETicket tkt = new CORETicket();

            //switch (coreAccount.SegmentName.ToLower())
            //{
            //    case "emerging":
            //    case "managed":
            //    case "rackspace cloud":
            //        tkt = new ManagedCORETicket();
            //        tkt.Status = (int)ManagedCORETicket.TicketStatus.ConfirmSolved;
            //        tkt.SubCategory = (int)ManagedCORETicket.TicketSubCategory.OSPatch;
            //        break;

            //    case "latam":
            //    case "enterprise services":
            //    case "corporate":
            //    case "intensive":
            //    case "managed colocation":
            //        tkt = new EnterpriseAmCORETicket();
            //        tkt.Status = (int)EnterpriseAmCORETicket.TicketStatus.New;
            //        tkt.SubCategory = (int)EnterpriseAmCORETicket.TicketSubcategory.WindowsPatching;
            //        break;

            //    case "ent z":
            //        tkt = new SegmentSupportCORETicket();
            //        tkt.Status = (int)SegmentSupportCORETicket.TicketStatus.New;
            //        tkt.SubCategory = (int)SegmentSupportCORETicket.TicketSubCategory.Other;
            //        break;
            //}

            if (coreAccount.SegmentName.ToLower() == "ent z")
            {
                tkt = new SegmentSupportCORETicket();
                tkt.Status = (int)SegmentSupportCORETicket.TicketStatus.New;
            }
            else
            {
                tkt = new EnterpriseCORETicket();
                tkt.Status = (int)EnterpriseCORETicket.TicketStatus.New;
            }

            tkt.Subject = $"Proactive Patching - {DateTime.Now.ToString("MMMM yyyy")} (Manual)";
            tkt.Account = coreAccount.Number;
            tkt.InitialMessage = ticketText;    //generated by parent class
            tkt.Recipients = coreAccount.CustomerContactIDs.ToArray();
            tkt.Requester = coreAccount.AM_ContactID;
            tkt.Severity = 1;
            tkt.SendMessageText = false;
            tkt.ComputerList = this.CoreDeviceList.ToArray();

            return tkt;
        }
    }
}
