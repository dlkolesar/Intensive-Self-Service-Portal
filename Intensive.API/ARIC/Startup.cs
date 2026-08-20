using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Data.EBIDataMart;
using Intensive.Data.SSDatabase;
using Intensive.Data.WSUS;
using Intensive.Services.Aric;
using Intensive.Services.Common;
using Intensive.Services.Patching;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace ARIC
{
    public class Startup
    {
        // NOTE:  https://blogs.msdn.microsoft.com/sqlexpress/2011/12/08/using-localdb-with-full-iis-part-1-user-profile/
        //private string connString;
        //private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=SSDatabase;Trusted_Connection=True;";
        //private string connString = @"Server=\\10.12.39.121;Database=ssDatabase;Trusted_Connection=True;";

        //public IConfigurationRoot PreConfiguration { get; }
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddDbConfiguration(options =>
                        options.UseSqlServer(configuration.GetConnectionString("ssDatabase"))
                    )
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        ); 

            services.AddCors(opts =>
                 opts.AddPolicy("allowAny", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
             );

            services.AddAuthentication(cfg =>
                cfg.AddScheme("RackspaceIdentityHandler", t => t.HandlerType = typeof(RackspaceIdentityAuthenticationHandler))
            );


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Default",
                                    policy => policy.Requirements.Add(new IdentityAuthRequirement())
                                 );
            });

            services.AddDbContext<SSDatabaseContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("ssDatabase"))
                     );


            string configKey = Configuration.GetValue<string>("AricConfigKey");

            string json = Configuration.GetValue<string>(configKey);


            AricSystemConfig ariccfg = JsonConvert.DeserializeObject<AricSystemConfig>(json);
            services.Configure<AricSystemConfig>(c =>
            {
                //c = adcfg;
                c.EventsAPI = ariccfg.EventsAPI;
                c.JobStatusUrl = ariccfg.JobStatusUrl;
                c.TimetableAPI = ariccfg.TimetableAPI;
            });


            string key = Configuration.GetValue<string>("WinPatchConfigKey");
            PatchingSystemConfig PatchingConfig = JsonConvert.DeserializeObject<PatchingSystemConfig>(Configuration.GetValue<string>(key));
            services.Configure<PatchingSystemConfig>(cfg =>
            {
                //cfg = PatchingConfig;
                cfg.DefaultClient = PatchingConfig.DefaultClient;
                cfg.DefaultScheduleDay = PatchingConfig.DefaultScheduleDay;
                cfg.DefaultWUServer = PatchingConfig.DefaultWUServer;
                cfg.ExcludeOSBuilds = PatchingConfig.ExcludeOSBuilds;
                cfg.LastContactTimeout = PatchingConfig.LastContactTimeout;
                cfg.LastPatchDateTimeout = PatchingConfig.LastPatchDateTimeout;
                cfg.MinimumOSBuild = PatchingConfig.MinimumOSBuild;
                cfg.StaleAccountAgeDays = PatchingConfig.StaleAccountAgeDays;
                cfg.SystemId = PatchingConfig.SystemId;
                cfg.WSUSDBServers = PatchingConfig.WSUSDBServers;
                cfg.WSUSGroupID = PatchingConfig.WSUSGroupID;
            }
             );

            services.AddScoped<AricProcess>();
            services.AddScoped<AricJob>();
            services.AddScoped<AricJobPayload>();
            services.AddScoped<AricTimeTable>();
            services.AddScoped<AricDataHandlerPatching>();
            services.AddScoped<PatchingClient>();
            services.AddTransient<WSUSDBContextFactory>();
            services.AddScoped<IAuthorizationHandler, IdentityAuthHandler>();
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("allowAny");

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
