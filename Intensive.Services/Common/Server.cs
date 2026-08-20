using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Intensive.Data.SSDatabase;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Intensive.Services.Common
{
    public class Server
    {
        public int DeviceNumber { get; set; }
        public Guid? WSUSID { get; set; }
        public string NimBUSRobotID { get; set; }
        public Guid? SCOMAgentID { get; set; }
        public int? AntiVirusID { get; set; }
        public string Name { get; set; }
        public int Account { get; set; }
        public string DataCenter { get; set; }
        public string OS { get; set; }
        public bool IsCluster { get; set; }
        public bool IsClusterNode { get; set; }
        public DateTime LastRefresh { get; set; }
        public List<Tag> Tags { get; set; }

        private SSDatabaseContext db;
        private ILogger<Server> log;

        public Server(SSDatabaseContext dbContext, ILogger<Server> logger)
        {
            db = dbContext;
            this.log = logger;
        }


        public Server(TbServers tsvr)
        {
            this.DeviceNumber = tsvr.DeviceNumber;
            this.WSUSID = tsvr.Wsusid;
            this.NimBUSRobotID = tsvr.NimBusrobotId;
            this.SCOMAgentID = tsvr.ScomagentId;
            this.AntiVirusID = tsvr.AntiVirusId;
            this.Name = tsvr.Name;
            this.Account = tsvr.Account;
            this.DataCenter = tsvr.DataCenter;
            this.OS = tsvr.Os;
            this.IsCluster = tsvr.IsCluster;
            this.IsClusterNode = tsvr.IsClusterNode;
            this.LastRefresh = tsvr.LastRefresh;
        }

        public async void Load(int number)
        {
            log.LogDebug($"[Common] Loading Server {number}....");
            TbServers tsvr = db.TbServers.First(a => a.DeviceNumber == number);
            this.DeviceNumber = tsvr.DeviceNumber;
            this.WSUSID = tsvr.Wsusid;
            this.NimBUSRobotID = tsvr.NimBusrobotId;
            this.SCOMAgentID = tsvr.ScomagentId;
            this.AntiVirusID = tsvr.AntiVirusId;
            this.Name = tsvr.Name;
            this.Account = tsvr.Account;
            this.DataCenter = tsvr.DataCenter;
            this.OS = tsvr.Os;
            this.IsCluster = tsvr.IsCluster;
            this.IsClusterNode = tsvr.IsClusterNode;
            this.LastRefresh = tsvr.LastRefresh;
            this.Tags = GetTagsAsync().Result;
            log.LogDebug($"[Common] Finished Loading Server {number}");
        }

        public List<Server> Find(int accountNumber)
        {
            log.LogDebug($"[Common] Finding Servers for account {accountNumber}....");
            List<TbServers> tbServers = db.TbServers.Where(a => a.Account == accountNumber).ToList<TbServers>();

            List<Server> servers = new List<Server>();
            Server svr;

            foreach (TbServers s in tbServers)
            {
                svr = new Server(s);
                servers.Add(svr);
            }

            return servers;
  
    }
        public virtual void Save()
        {
            TbServers tbServer;
            try
            {
                tbServer = db.TbServers.First(a => a.DeviceNumber == this.DeviceNumber);
                tbServer.Wsusid = this.WSUSID;
                tbServer.NimBusrobotId = this.NimBUSRobotID;
                tbServer.ScomagentId = this.SCOMAgentID;
                tbServer.AntiVirusId = this.AntiVirusID;
                tbServer.Name = this.Name;
                tbServer.Account = this.Account;
                tbServer.DataCenter = this.DataCenter;
                tbServer.Os = this.OS;
                tbServer.IsCluster = this.IsCluster;
                tbServer.IsClusterNode = this.IsClusterNode;
                tbServer.LastRefresh = this.LastRefresh;
                db.TbServers.Update(tbServer);

            }
            catch (InvalidOperationException nf)
            {
                tbServer = new TbServers();
                tbServer.DeviceNumber = this.DeviceNumber;
                tbServer.Wsusid = this.WSUSID;
                tbServer.NimBusrobotId = this.NimBUSRobotID;
                tbServer.ScomagentId = this.SCOMAgentID;
                tbServer.AntiVirusId = this.AntiVirusID;
                tbServer.Name = this.Name;
                tbServer.Account = this.Account;
                tbServer.DataCenter = this.DataCenter;
                tbServer.Os = this.OS;
                tbServer.IsCluster = this.IsCluster;
                tbServer.IsClusterNode = this.IsClusterNode;
                tbServer.LastRefresh = this.LastRefresh;
                db.TbServers.Add(tbServer);
            }
            finally
            {
                db.SaveChanges();
            }
        }

        public async Task AssignTagsAsync(Tag tag)
        {
            TbServerTags svrTag;

            svrTag = new TbServerTags();
            svrTag.DeviceNumber = this.DeviceNumber;
            svrTag.TagId = tag.ID;

            await db.TbServerTags.AddAsync(svrTag);

            if (!this.Tags.Contains(tag))
            {
                this.Tags.Add(tag);
            }

            await db.SaveChangesAsync();
        }

        public async Task RemoveAllTagsAsync()
        {
            List<TbServerTags> lstTags = await db.TbServerTags
                                .Where(t => t.DeviceNumber == this.DeviceNumber)
                                .ToListAsync<TbServerTags>();
            if (lstTags.Count > 0) 
            {
                db.TbServerTags.RemoveRange(lstTags);
                await db.SaveChangesAsync();
            }
            this.Tags.Clear(); 
        }


        public async Task RemoveTagAsync(Tag oldTag)
        {
            TbServerTags svrTag;
            if (db == null) { throw new ArgumentNullException("db"); }
            if (oldTag == null) { throw new ArgumentNullException("oldTag"); }


            if (this.Tags.Contains(oldTag))
            {
                this.Tags.Remove(oldTag);
            }

            //try to get the current assignment from the db
            svrTag = await db.TbServerTags
                                .SingleOrDefaultAsync(t => t.TagId == oldTag.ID 
                                                        && t.DeviceNumber == this.DeviceNumber);
            if (svrTag != null) // if found in db
            {
                db.TbServerTags.Remove(svrTag);
                await db.SaveChangesAsync();
            }
        }

        public void RemoveTag(Tag oldTag)
        {
            TbServerTags svrTag;
            if (db == null) { throw new ArgumentNullException("db"); }
            if (oldTag == null) { throw new ArgumentNullException("oldTag"); }


            if (this.Tags.Contains(oldTag))
            {
                this.Tags.Remove(oldTag);
            }

            //try to get the current assignment from the db
            svrTag = db.TbServerTags
                                .SingleOrDefault(t => t.TagId == oldTag.ID
                                                        && t.DeviceNumber == this.DeviceNumber);
            if (svrTag != null) // if found in db
            {
                db.TbServerTags.Remove(svrTag);
                db.SaveChanges();
            }
        }



        public async Task<List<Tag>> GetTagsAsync()
        {
            List<Tag> tags = new List<Tag>();

            log.LogDebug($"Searching for tags on Server {this.DeviceNumber}....");
            List<int> tagids = await db.TbServerTags.AsNoTracking()
                                    .Where(t => t.DeviceNumber == this.DeviceNumber)
                                    .Select(t => t.TagId)
                                    .ToListAsync<int>();
            log.LogDebug($"{tagids.Count} tags found for Server {this.DeviceNumber}");
            log.LogDebug($"{JsonConvert.SerializeObject(tagids)}");

            if (tagids.Count > 0)
            {
                log.LogDebug($"Searching for tag data on ids: {tagids}");
                List<TbTags> lstTags = await db.TbTags.AsNoTracking()
                            .Where(t => tagids.Contains(t.Id))
                            .ToListAsync<TbTags>();

                Tag t;
                foreach (TbTags tbTag in lstTags)
                {
                    t = new Tag();
                    t.ID = tbTag.Id;
                    t.Account = tbTag.Account;
                    t.TagName = tbTag.Tag.Trim();
                    tags.Add(t);
                }
            }
            log.LogDebug($"Tag Data:");
            log.LogDebug($"{JsonConvert.SerializeObject(tags)}");
            return tags;
        }

    }

    
}
