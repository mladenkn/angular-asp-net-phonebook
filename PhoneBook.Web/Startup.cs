using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.DAL;
using PhoneBook.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace PhoneBook.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private bool _useSsr = false;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BetingSystem API", Version = "v1" });
            });


            // In production, the Angular files will be served from this directory
            if (_useSsr)
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });

            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<PhoneBookDbContext>(o => o.UseInMemoryDatabase("PhonebookDb"));

            services.AddAutoMapper(o => o.AddProfile<MapperProfile>());

            services.AddTransient<IContactsService, ContactsService>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISafeRunner, SafeRunner>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(o => o.AllowCredentials().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            if(_useSsr)
                app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (_useSsr)
                app.UseSpa(spa =>
                {
                     // To learn more about options for serving an Angular SPA from ASP.NET Core,
                     // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
        }
    }
}
