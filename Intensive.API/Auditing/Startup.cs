using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Data.SSDatabase;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;


namespace Auditing
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x =>
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

            connString = Configuration.GetConnectionString("ssDatabase");
            services.AddDbContext<SSDatabaseContext>(options => options.UseSqlServer(connString));

            services.AddScoped<AuditTrail>();
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
