using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Data.ADMT;
using Intensive.Data.SSDatabase;
using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Newtonsoft.Json;
using Serilog;

namespace ActiveDirectory.Intensive
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
            services.AddControllers().AddNewtonsoftJson(x =>
                            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        ); 

            services.AddCors(opts =>
                opts.AddPolicy("allowAny", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
            );

            //services.AddAuthentication(cfg =>
            //{
            //    cfg.DefaultScheme = "RackspaceIdentityHandler";
            //})
            //    .AddRackspaceIdentityAuthentication("RackspaceIdentityHandler", "Rackspace Identity Authentication Handler",null);

            services.AddAuthentication(cfg =>

                cfg.AddScheme("RackspaceIdentityHandler", t => t.HandlerType = typeof(RackspaceIdentityAuthenticationHandler))
            );



            services.AddAuthorization(options =>
            {
                
                options.AddPolicy("UserMatch",
                                    policy => policy.AddRequirements(new IdentityAuthRequirement(),
                                                                 new CurrentUserMatchesRequestRequirement()
                                                                )
                             );

                options.AddPolicy("Default",
                                    policy => policy.Requirements.Add(new IdentityAuthRequirement())
                                 );

                options.AddPolicy("UserAdmin",
                                   policy => policy.Requirements.Add(new UserAdminRequirement())
                                );

                options.AddPolicy("GroupAdmin",
                   policy => policy.Requirements.Add(new GroupAdminRequirement())
                );


                options.AddPolicy("ComputerAdmin",
                   policy => policy.Requirements.Add(new ComputerAdminRequirement())
                );


                options.AddPolicy("ContainerAdmin",
                   policy => policy.Requirements.Add(new ContainerAdminRequirement())
                );

            });

            //services.AddLogging();

            //connString = Configuration.GetConnectionString("admt");
            //services.AddDbContext<ADMTContext>(options => options.UseSqlServer(connString));

            connString = Configuration.GetConnectionString("ssDatabase");
            services.AddDbContext<SSDatabaseContext>(options => options.UseSqlServer(connString));


            //services.AddOptions();
            //services.AddSingleton<IConfiguration>(Configuration);

            string adconfigKey = Configuration.GetValue<string>("AdConfigKey");

            string json = Configuration.GetValue<string>(adconfigKey);


            AdSystemConfig adcfg = JsonConvert.DeserializeObject<AdSystemConfig>(json);
            services.Configure<AdSystemConfig>(c =>
            {
                //c = adcfg;
                c.SystemId = adcfg.SystemId;
                c.PasswordLength = adcfg.PasswordLength;
                c.PasswordLifeHours = adcfg.PasswordLifeHours;
                c.DomainFQDN = adcfg.DomainFQDN;
                c.DomainName = adcfg.DomainName;
                c.AccountAccessLifeHours = adcfg.AccountAccessLifeHours;
            });

            ADMTConfig admtcfg = JsonConvert.DeserializeObject<ADMTConfig>(Configuration.GetValue<string>("ADMT"));

            services.Configure<ADMTConfig>(c =>
            {
                //c = admtcfg;
                //c.AdminPassword = admtcfg.AdminPassword;
                //c.AdminUser = admtcfg.AdminUser;
                //c.Database = admtcfg.Database;
                //c.ExeName = admtcfg.ExeName;
                //c.OptionsFile = admtcfg.OptionsFile;
                //c.Path = admtcfg.Path;
                c.ADMTServers = admtcfg.ADMTServers;
                //c.SourceDomainControllers = admtcfg.SourceDomainControllers;
                //c.TargetDomainControllers = admtcfg.TargetDomainControllers;
            });

            services.AddScoped<ADMTDBContextFactory>();
            services.AddSingleton<ActiveDirectoryService>();
            services.AddSingleton<AdGeneratedPassword>();
            services.AddScoped<AdDomain>();
            services.AddScoped<AdObject>();
            services.AddScoped<AdUser>();
            services.AddScoped<AdGroup>();
            services.AddScoped<AdContainer>();
            services.AddScoped<AdMigration>();
            services.AddScoped<AdMigrationHistory>();
            services.AddScoped<AuditTrail>();
            services.AddScoped<IAuthorizationHandler, IdentityAuthHandler>();
            services.AddScoped<IAuthorizationHandler, CurrentUserMatchesRequestHandler>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
