using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Data.EBIDataMart;
using Intensive.Data.SSDatabase;
using Intensive.Data.WSUS;
using Intensive.Services.Aric;
using Intensive.Services.Auditing;
using Intensive.Services.Common;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.Patching;
using Intensive.Services.Patching.TicketGenerator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Patching
{
    public class Startup
    {
        // NOTE:  https://blogs.msdn.microsoft.com/sqlexpress/2011/12/08/using-localdb-with-full-iis-part-1-user-profile/
        private string connString;
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
                opts.AddPolicy("allowAny", p => p.AllowAnyOrigin()
                                                 .AllowAnyMethod()
                                                 .AllowAnyHeader()
                              )
            );

            services.AddAuthentication(cfg =>
                cfg.AddScheme("RackspaceIdentityHandler", t => t.HandlerType = typeof(RackspaceIdentityAuthenticationHandler))
            );


            services.AddAuthorization(options =>
                options.AddPolicy("TokenRequired", policy => policy.Requirements.Add(new IdentityAuthRequirement()))
            );
            string connString = string.Empty;



            connString = Configuration.GetConnectionString("DataMart");

            //services.AddDbContext<Corporate_DMARTContext>(options => options.UseSqlServer(connString));
            DbContextOptionsBuilder<Corporate_DMARTContext> bldr = new DbContextOptionsBuilder<Corporate_DMARTContext>();
            bldr.UseSqlServer<Corporate_DMARTContext>(connString);
            services.TryAddSingleton(bldr.Options);
            services.AddSingleton<DbContextOptions>(p => p.GetRequiredService<DbContextOptions<Corporate_DMARTContext>>());

            services.TryAdd(new ServiceDescriptor(typeof(Corporate_DMARTContext), typeof(Corporate_DMARTContext), ServiceLifetime.Scoped));


            connString = Configuration.GetConnectionString("ssDatabase");
            //services.AddDbContext<SSDatabaseContext>(options => options.UseSqlServer(connString));

            DbContextOptionsBuilder<SSDatabaseContext> bldr1 = new DbContextOptionsBuilder<SSDatabaseContext>();
            bldr1.UseSqlServer<SSDatabaseContext>(connString);
            services.TryAddSingleton(bldr1.Options);
            services.AddSingleton<DbContextOptions>(p => p.GetRequiredService<DbContextOptions<SSDatabaseContext>>());

            services.TryAdd(new ServiceDescriptor(typeof(SSDatabaseContext), typeof(SSDatabaseContext), ServiceLifetime.Scoped));

            //connString = Configuration.GetConnectionString("SUSDB");
            //services.AddDbContext<SUSDBContext>(options => options.UseSqlServer(connString));


            services.AddScoped<AuditTrail>();
            services.AddScoped<AricJob>();
            services.AddScoped<AricDataHandlerPatching>();
            services.AddScoped<AricTimeTable>();

            services.AddScoped<PatchingAccount>();
            services.AddScoped<PatchingClient>();
            services.AddScoped<Server>();
            services.AddScoped<PatchingTicketHistory>();
            services.AddScoped<PatchStatus>();
            services.AddScoped<PatchingTicketGenerator>();
            services.AddScoped<AutomaticPatchingTicket>();
            services.AddScoped<ManualPatchingTicket>();

            services.AddScoped<IAuthorizationHandler, IdentityAuthHandler>();

            services.AddOptions();
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
                cfg.AricCallbackUrl = PatchingConfig.AricCallbackUrl;
                cfg.MinimumOSBuild = PatchingConfig.MinimumOSBuild;
                cfg.StaleAccountAgeDays = PatchingConfig.StaleAccountAgeDays;
                cfg.SystemId = PatchingConfig.SystemId;
                cfg.WSUSDBServers = PatchingConfig.WSUSDBServers;
                cfg.WSUSGroupID = PatchingConfig.WSUSGroupID;
            }
             );

            key = Configuration.GetValue<string>("AricConfigKey");
            AricSystemConfig AricConfig = JsonConvert.DeserializeObject<AricSystemConfig>(Configuration.GetValue<string>(key));
            services.Configure<AricSystemConfig>(cfg =>
            {
                //cfg = AricConfig;
                cfg.EventsAPI = AricConfig.EventsAPI;
                cfg.JobStatusUrl = AricConfig.JobStatusUrl;
                cfg.TimetableAPI = AricConfig.TimetableAPI;
            });

            key = "PatchingTicketGenerator";
            GeneratorConfig PTGConfig = JsonConvert.DeserializeObject<GeneratorConfig>(Configuration.GetValue<string>(key));
            services.Configure<GeneratorConfig>(cfg =>
            {
                cfg.ApprovedUpdates = PTGConfig.ApprovedUpdates;
                cfg.COREPwd = PTGConfig.COREPwd;
                cfg.CoreURL = PTGConfig.CoreURL;
                cfg.COREUser = PTGConfig.COREUser;
                cfg.DeclinedUpdates = PTGConfig.DeclinedUpdates;
                cfg.EmailRecipients = PTGConfig.EmailRecipients;
                cfg.SMTPPwd = PTGConfig.SMTPPwd;
                cfg.SMTPServerName = PTGConfig.SMTPServerName;
                cfg.SMTPUser = PTGConfig.SMTPUser;
                cfg.TicketTemplate = PTGConfig.TicketTemplate;
            });

            key = Configuration.GetValue<string>("CoreConfigKey");
            JObject jo = JObject.Parse(Configuration.GetValue<string>(key));
            CTKAPI core = new CTKAPI(jo["server"].ToString(), jo["user"].ToString(), jo["password"].ToString());
            services.AddSingleton<CTKAPI>(core);

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<WSUSDBContextFactory>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("allowAny");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
