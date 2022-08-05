using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Saraha.Core.Common;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using Saraha.Infra.Common;
using Saraha.Infra.Repository;
using Saraha.Infra.Service;

namespace Saraha
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IDbcontext, Dbcontext>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IReportService, ReportService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}