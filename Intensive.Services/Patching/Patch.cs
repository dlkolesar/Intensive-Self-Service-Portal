using System;
using System.Collections.Generic;
using System.Linq;

using Intensive.Data.SSDatabase;
using Intensive.Data.WSUS;
//using Microsoft.UpdateServices.Administration;

using Intensive.Services.Patching.Exceptions;
using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Extensions;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Intensive.Services.Patching
{
    public class Patch
    {
        public Guid PatchId { get; set; }
        public int LocalId { get; set; }
        public string Title { get; set; }
        public bool RequiresReboot { get; set; }
        public string Severity { get; set; }
        public string Bulletin { get; set; }
        public string KbArticle { get; set; }
        public string Url { get; set; }
        public DateTime ReleaseDate { get; set; }


        protected ILogger log;
        protected SSDatabaseContext db;

        protected WSUSDBContextFactory wsusDBFactory;
        protected SUSDBContext wsus;
        protected PatchingSystemConfig config;

        public Patch() { }

        //public Patch(ILogger<PatchingClient> logger,
        //                     SSDatabaseContext dbContext,
        //                     WSUSDBContextFactory wsusFactory,
        //                     IOptions<PatchingSystemConfig> patchConfig
        //                     )
        //{
        //    log = logger;
        //    db = dbContext;
        //    wsusDBFactory = wsusFactory;
        //    config = patchConfig.Value;
        //}

        //public void Load(string dc, Guid patchid)
        //{
        //    try
        //    {
        //        log.LogInformation($"Creating connection to WSUS Server '{config.WSUSDBServers[dc]}'...");
        //        wsus = wsusDBFactory.Create(config.WSUSDBServers[dc]);

        //        wsus.Database.OpenConnection();

        //        DbCommand cmd = wsus.Database.GetDbConnection().CreateCommand();
        //        cmd.CommandText = "spGetUpdateByID";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        SqlParameter p = new SqlParameter("@updateID", SqlDbType.UniqueIdentifier);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = patchid;
        //        cmd.Parameters.Add(p);

        //        p = new SqlParameter("@revisionNumber", SqlDbType.Int);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = 0;
        //        cmd.Parameters.Add(p);

        //        p = new SqlParameter("@preferredCulture", SqlDbType.NVarChar);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = "en";
        //        cmd.Parameters.Add(p);

        //        p = new SqlParameter("@apiVersion", SqlDbType.Int);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = 196608;
        //        cmd.Parameters.Add(p);


        //        //spGetUpdateByID returns 6 result sets of data
        //        // 1. contains the bulk of the Patch Information
        //        // 2. contains Category information, which we are not interested in
        //        // 3. contains the KB Article number
        //        // 4. contains the Security Bulletin ID
        //        // 5. contains the URL link to the patch
        //        // 6. contains the result code of the stored proc execution -- 0=success,1=fail

        //        using (DbDataReader reader = cmd.ExecuteReader())
        //        {
        //            //dbDataReader automatically starts on the first result set
        //            if ((reader.HasRows) && (reader.Read()))
        //            {
        //                this.PatchId = patchid;
        //                this.LocalId = reader.GetInt32(3);
        //                this.RequiresReboot = reader.GetInt32(7) > 0;
        //                this.Severity = reader.GetString(28);
        //                this.Title = reader.GetString(29);

        //                reader.NextResult();    // skip the second result set, which contains Category data

        //                reader.NextResult();
        //                if (reader.Read())
        //                {
        //                    this.KbArticle = reader.GetString(1);
        //                }

        //                reader.NextResult();
        //                if (reader.Read())
        //                {
        //                    this.Bulletin = reader.GetString(1);
        //                }

        //                reader.NextResult();
        //                if (reader.Read())
        //                {
        //                    this.Url = reader.GetString(1);
        //                }
        //            }

        //            reader.Close();
        //        }//using
        //    }//try

        //    catch (SqlException sqlex)
        //    {
        //        log.LogInformation($"==>SQL Error Code: {sqlex.ErrorCode}");
        //        log.LogInformation($"==>SQL Error Message: [{sqlex.Number}] {sqlex.Message}");
        //        log.LogInformation($"==>SQL Procedure: {sqlex.Procedure}");
        //        log.LogInformation($"==>SQL Error State: {sqlex.State}");
        //        throw new PatchingWSUSNotFoundException($"Unable to connect to the Intensive WSUS server");
        //    }
        //}

        //public void LoadView(string dc, Guid patchid)
        //{
        //    try
        //    {
        //        log.LogInformation($"Creating connection to WSUS Server '{config.WSUSDBServers[dc]}'...");
        //        wsus = wsusDBFactory.Create(config.WSUSDBServers[dc]);

        //        wsus.Database.OpenConnection();

        //        DbCommand cmd = wsus.Database.GetDbConnection().CreateCommand();
        //        cmd.CommandText = "";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        SqlParameter p = new SqlParameter("@updateID", SqlDbType.UniqueIdentifier);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = patchid;
        //        cmd.Parameters.Add(p);

        //        p = new SqlParameter("@revisionNumber", SqlDbType.Int);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = 0;
        //        cmd.Parameters.Add(p);

        //        p = new SqlParameter("@preferredCulture", SqlDbType.NVarChar);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = "en";
        //        cmd.Parameters.Add(p);

        //        p = new SqlParameter("@apiVersion", SqlDbType.Int);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = 196608;
        //        cmd.Parameters.Add(p);


        //        //spGetUpdateByID returns 6 result sets of data
        //        // 1. contains the bulk of the Patch Information
        //        // 2. contains Category information, which we are not interested in
        //        // 3. contains the KB Article number
        //        // 4. contains the Security Bulletin ID
        //        // 5. contains the URL link to the patch
        //        // 6. contains the result code of the stored proc execution -- 0=success,1=fail

        //        using (DbDataReader reader = cmd.ExecuteReader())
        //        {
        //            //dbDataReader automatically starts on the first result set
        //            if ((reader.HasRows) && (reader.Read()))
        //            {
        //                this.PatchId = patchid;
        //                this.LocalId = reader.GetInt32(3);
        //                this.RequiresReboot = reader.GetInt32(7) > 0;
        //                this.Severity = reader.GetString(28);
        //                this.Title = reader.GetString(29);

        //                reader.NextResult();    // skip the second result set, which contains Category data

        //                reader.NextResult();
        //                if (reader.Read())
        //                {
        //                    this.KbArticle = reader.GetString(1);
        //                }

        //                reader.NextResult();
        //                if (reader.Read())
        //                {
        //                    this.Bulletin = reader.GetString(1);
        //                }

        //                reader.NextResult();
        //                if (reader.Read())
        //                {
        //                    this.Url = reader.GetString(1);
        //                }
        //            }

        //            reader.Close();
        //        }//using
        //    }//try

        //    catch (SqlException sqlex)
        //    {
        //        log.LogInformation($"==>SQL Error Code: {sqlex.ErrorCode}");
        //        log.LogInformation($"==>SQL Error Message: [{sqlex.Number}] {sqlex.Message}");
        //        log.LogInformation($"==>SQL Procedure: {sqlex.Procedure}");
        //        log.LogInformation($"==>SQL Error State: {sqlex.State}");
        //        throw new PatchingWSUSNotFoundException($"Unable to connect to the Intensive WSUS server");
        //    }
        //}

    }
}
