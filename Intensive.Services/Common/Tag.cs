using System;
using System.Collections.Generic;
using System.Linq;
using Intensive.Data.SSDatabase;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Intensive.Services.Common
{
    public class Tag
    {
        public int ID { get; set; }
        public int? Account { get; set; }
        public string TagName { get; set; }


        ILogger<Tag> log;
        SSDatabaseContext db;


        public Tag() { }

        public Tag(ILogger<Tag> logger, SSDatabaseContext dbContext)

        {
            log = logger;
            db = dbContext;
        }

        public async Task Load(int id)
        {
            TbTags t;

            try
            {
                t = await db.TbTags.SingleAsync(t => t.Id == id);
                this.TagName = t.Tag.Trim();
                this.ID = t.Id;
                this.Account = t.Account;
            }
            catch (InvalidOperationException)
            {
                throw new TagNotFoundException($"Tag with id '{id.ToString()}' does not exist in the database");
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public async Task Load(int account, string tag)
        {
            TbTags t;

            try
            {
                t = await db.TbTags.SingleAsync(t => t.Account == account 
                                               && t.Tag.ToLower() == tag.ToLower());
                this.TagName = t.Tag.Trim();
                this.ID = t.Id;
                this.Account = t.Account;
            }
            catch (InvalidOperationException)
            {
                throw new TagNotFoundException($"Tag '{tag}' in account {account} does not exist in the database");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Tag>> Find(int? account)
        {
            Tag newTag = new Tag();
            List<Tag> lst = new List<Tag>();
            try
            {
                List<TbTags> tagSet = await db.TbTags.AsNoTracking()
                                    .Where(t => t.Account == account)
                                    .ToListAsync<TbTags>();

               foreach(TbTags t in tagSet)
               {
                    newTag = new Tag();
                    newTag.Account = t.Account;
                    newTag.ID = t.Id;
                    newTag.TagName = t.Tag.Trim();

                    lst.Add(newTag);
               }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lst;
        }


        public async Task Save()
        {
            TbTags oldTag;

            try
            {
                oldTag = db.TbTags.Single(t => t.Id == this.ID);
                oldTag.Tag = this.TagName.Trim();
                await db.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                //not found.  Create a new one
                TbTags newTag = new TbTags();
                newTag.Account = this.Account;
                newTag.Tag = this.TagName.Trim();
                await db.TbTags.AddAsync(newTag);
                await db.SaveChangesAsync();

            }

        }

        public async Task Delete()
        {
            TbTags oldTag;

            oldTag = db.TbTags.Single(t => t.Id == this.ID);
            db.TbTags.Remove(oldTag);
            await db.SaveChangesAsync();
        }
    }
}
