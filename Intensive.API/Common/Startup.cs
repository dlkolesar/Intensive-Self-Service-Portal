using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Data.EBIDataMart;
using Intensive.Data.SSDatabase;
using Intensive.Services.Auditing;
//using Intensive.Services.Aric;
using Intensive.Services.Common;
using Intensive.Services.CTKAPIWrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Common
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

            services.AddAuthentication(cfg =>
               cfg.AddScheme("RackspaceIdentityHandler", t => t.HandlerType = typeof(RackspaceIdentityAuthenticationHandler))
           );


            services.AddAuthorization(options =>
                options.AddPolicy("TokenRequired", policy => policy.Requirements.Add(new IdentityAuthRequirement()))
            );

            services.AddDbContext<SSDatabaseContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("ssDatabase"))
                     );

            services.AddDbContext<Corporate_DMARTContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DataMart"))
                     );

            string coreConfig = Configuration.GetValue<string>("CORE");
            JObject jCore = JObject.Parse(coreConfig);
            CTKAPI core = new CTKAPI(jCore["server"].ToString(), jCore["user"].ToString(), jCore["password"].ToString());


            services.AddScoped<Account>();
            services.AddScoped<Server>();
            services.AddScoped<Tag>();
            services.AddScoped<AuditTrail>();
            services.AddSingleton<CTKAPI>(core);

            //services.AddScoped<AricProcess>();
            services.AddScoped<IAuthorizationHandler, IdentityAuthHandler>();
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
