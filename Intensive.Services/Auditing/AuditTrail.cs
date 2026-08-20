using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using Newtonsoft.Json;
using LinqKit;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace Intensive.Services.Auditing
{
    public class AuditTrail
    {
        public int Id { get; set; }
        public int SystemId { get; set; }
        public int? DeviceNumber { get; set; }
        public int? Account { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Detail { get; set; }
        public DateTime TimeStamp { get; set; }

        SSDatabaseContext db;
        ILogger<AuditTrail> log;
        public AuditTrail(SSDatabaseContext dbContext, ILogger<AuditTrail> logger)
        {
            db = dbContext;
            log = logger;
        }

        public void Save()
        {
            TbAuditTrail tbAuditTrail = new TbAuditTrail();

            //if there is a dev# but no acct number, lookup the account from the dev#
            if ( (this.DeviceNumber != null) && (this.Account == 0))
            {
                TbServers svr = db.TbServers.Single(s => s.DeviceNumber == this.DeviceNumber);
                this.Account = svr.Account;
            }

            tbAuditTrail.Account = this.Account;
            tbAuditTrail.Action = this.Action;
            tbAuditTrail.Detail = this.Detail;
            tbAuditTrail.DeviceNumber = this.DeviceNumber;
            tbAuditTrail.SystemId = this.SystemId;
            tbAuditTrail.TimeStamp = this.TimeStamp;
            tbAuditTrail.UserId = this.UserId;

            db.TbAuditTrail.Add(tbAuditTrail);

            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            TbAuditTrail tbAuditTrail = new TbAuditTrail();

            //if there is a dev# but no acct number, lookup the account from the dev#
            if ((this.DeviceNumber != null) && (this.Account == 0))
            {
                TbServers svr = db.TbServers.Single(s => s.DeviceNumber == this.DeviceNumber);
                this.Account = svr.Account;
            }

            tbAuditTrail.Account = this.Account;
            tbAuditTrail.Action = this.Action;
            tbAuditTrail.Detail = this.Detail;
            tbAuditTrail.DeviceNumber = this.DeviceNumber;
            tbAuditTrail.SystemId = this.SystemId;
            tbAuditTrail.TimeStamp = this.TimeStamp;
            tbAuditTrail.UserId = this.UserId;

            db.TbAuditTrail.Add(tbAuditTrail);

            await db.SaveChangesAsync();
        }

        public void Load(int id)
        {
            TbAuditTrail result = db.TbAuditTrail.Single(a => a.Id == id);

            this.Id = result.Id;
            this.Account = result.Account;
            this.Action = result.Action;
            this.Detail = result.Detail;
            this.DeviceNumber = result.DeviceNumber;
            this.SystemId = result.SystemId;
            this.TimeStamp = result.TimeStamp;
            this.UserId = result.UserId;
        }


        public List<AuditTrail> LoadFiltered(int? account, int? device, int? systemid, string sso, string action)
        {

            //third-party depenedency - LinqKit
            // http://www.albahari.com/nutshell/predicatebuilder.aspx
            // https://www.codeproject.com/Articles/28580/LINQ-and-Dynamic-Predicate-Construction-at-Runtime
            var predicate = PredicateBuilder.New<TbAuditTrail>();

            if ( (account != null) && (account > 0))
            {
                predicate.And(a => a.Account == account);
            }

            if ((device != null) && (device > 0))
            {
                predicate.And(a => a.DeviceNumber == device);
            }
            if ((systemid != null) && (systemid > 0))
            {
                predicate.And(a => a.SystemId == systemid);
            }

            if (sso != null) 
            {
                predicate.And(a => a.UserId.ToLower().Contains(sso));
            }

            if (action != null)
            {
                predicate.And(a => a.Action.ToLower().Contains(action));
            }

            //if (before != null)
            //{
            //    predicate.And(a => a.TimeStamp < before);
            //}

            //if (after != null)
            //{
            //    predicate.And(a => a.TimeStamp > after);
            //}
            List<TbAuditTrail> results = db.TbAuditTrail.AsExpandable()
                                                .Where(predicate)
                                                .OrderByDescending(a => a.TimeStamp)
                                                .ToList<TbAuditTrail>();

            log.LogInformation($"results: {results.Count}");
            

            //a tricky way of copying one object to another when they have the same schema/properties
            // -- serialize the source object into JSON
            // -- then deserialize that JSON into the new object
            //
            List<AuditTrail> list = JsonConvert.DeserializeObject<List<AuditTrail>>(JsonConvert.SerializeObject(results));

            return list;
        }
    }
}
