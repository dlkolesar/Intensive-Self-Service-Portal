using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class PatchingTicketHistory
    {
        public int Account { get; set; }
        public string CoreTicket { get; set; }
        public string RunId { get; set; }
        public string TicketType { get; set; }
        public bool Updated { get; set; }


        ILogger log;
        SSDatabaseContext db;

        public PatchingTicketHistory() { }

        public PatchingTicketHistory(ILogger<PatchingTicketHistory> logger,
                                     SSDatabaseContext dbContext
                                    )
        {
            this.log = logger;
            this.db = dbContext;
            this.Updated = false;
        }

        public PatchingTicketHistory(string runid, int account, string ticket, string ticketType)
        {
            this.Account = account;
            this.CoreTicket = ticket;
            this.RunId = runid;
            this.TicketType = ticketType;
            this.Updated = false;
        }


        public void Load(string ticket)
        {
            TbPatchingTicketHistory r = db.TbPatchingTicketHistory
                                                        .AsNoTracking()
                                                        .Single(t => t.CoreTicket == ticket);
            this.Account = r.Account;
            this.CoreTicket = r.CoreTicket;
            this.RunId = r.RunId;
            this.TicketType = string.Empty;
            this.Updated = r.Updated;
        }


       

        public List<PatchingTicketHistory> Find(int? account, string runid)
        {
            //third-party depenedency - LinqKit
            // http://www.albahari.com/nutshell/predicatebuilder.aspx
            // https://www.codeproject.com/Articles/28580/LINQ-and-Dynamic-Predicate-Construction-at-Runtime
            var predicate = PredicateBuilder.New<TbPatchingTicketHistory>();

            if ((account != null) && (account > 0))
            {
                predicate.And(a => a.Account == account);
            }

            if (!string.IsNullOrEmpty(runid))
            {
                predicate.And(a => a.RunId == runid);
            }


            List<PatchingTicketHistory> list = new List<PatchingTicketHistory>();
            PatchingTicketHistory pth;

            List<TbPatchingTicketHistory> rows = db.TbPatchingTicketHistory
                                                        .AsNoTracking()
                                                        .AsExpandable()
                                                        .Where(predicate)
                                                        .ToList<TbPatchingTicketHistory>();


            foreach (TbPatchingTicketHistory r in rows)
            {
                pth = new PatchingTicketHistory();
                pth.Account = r.Account;
                pth.CoreTicket = r.CoreTicket;
                pth.RunId = r.RunId;
                pth.TicketType = r.TicketType;
                pth.Updated = r.Updated;

                list.Add(pth);
            }

            return list;
        }


        public void Save()
        {
            TbPatchingTicketHistory newHistory = new TbPatchingTicketHistory();
            newHistory.Account = this.Account;
            newHistory.CoreTicket = this.CoreTicket;
            newHistory.RunId = this.RunId;
            newHistory.TicketType = this.TicketType;
            newHistory.Updated = false;

            db.TbPatchingTicketHistory.Add(newHistory);

            db.SaveChanges();
        }

        public void SetUpdateFlag(bool updated)
        {
            TbPatchingTicketHistory r = db.TbPatchingTicketHistory
                                                .Single<TbPatchingTicketHistory>(t => t.CoreTicket == this.CoreTicket);

            r.Updated = updated;
            db.SaveChanges();
        }

        public void IntializeProgress(string runid)
        {
            TbPatchingTicketHistory r = new TbPatchingTicketHistory();
            r.Account = -1;
            r.RunId = runid;
            r.TicketType = "Progress";
            r.CoreTicket = "0"; //percent complete
            r.Updated = false;
            db.TbPatchingTicketHistory.Add(r);
            db.SaveChanges();
        }
        public void UpdateProgress(string runid, double pct)
        {
            TbPatchingTicketHistory r = db.TbPatchingTicketHistory
                                                .Single<TbPatchingTicketHistory>(t => t.RunId == runid && t.Account == -1);


            r.CoreTicket = String.Format("{0:0.00}", pct); ;
            db.SaveChanges();
        }

        public void TerminateProgress(string runid)
        {
            TbPatchingTicketHistory r = db.TbPatchingTicketHistory
                                                .Single<TbPatchingTicketHistory>(t => t.RunId == runid && t.Account == -1);

            db.TbPatchingTicketHistory.Remove(r);
            db.SaveChanges();
        }
    }
}
