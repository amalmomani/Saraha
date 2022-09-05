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
            services.AddCors(corsOptions =>

            {

                corsOptions.AddPolicy("policy",

                builder =>

                {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });

            });


            services.AddControllers();
            services.AddScoped<IDbcontext, Dbcontext>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IContactusRepository, ContactusRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPostlikeRepository, PostlikeRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPostcommentRepository, PostcommentRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAddsRepository, AddsRepository>();

            services.AddScoped<IVisaCardRepository, VisaCardRepository>();
            services.AddScoped<IVisaCardServices, VisaCardService>();


            services.AddScoped<IAddsService, AddsService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IContactusService, ContactusService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPostlikeService, PostlikeService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPostcommentService, PostcommentService>();
            services.AddScoped<IFeatureService, FeatureService>();





         

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
            app.UseCors("policy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
