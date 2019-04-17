using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Abstract;
using PhoneBook.DAL;
using PhoneBook.DAL.Abstract;
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

        private readonly bool _useSsr = false;
        private readonly bool _useMemoryDb = true;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Phonebook API", Version = "v1" });
            });

            // In production, the Angular files will be served from this directory
            if (_useSsr)
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });

            services.AddAutoMapper(o => o.AddProfile<MapperProfile>());
            services.AddTransient<ISafeRunner, SafeRunner>();
            
            if (_useMemoryDb)
                services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<PhoneBookDbContext>(o =>
            {
                if (_useMemoryDb)
                    o.UseInMemoryDatabase("PhonebookDb");
                else if (!_useMemoryDb)
                {
                    var cs =
                        @"Server=(localdb)\mssqllocaldb;Database=Phonebook;Trusted_Connection=True;ConnectRetryCount=0;Integrated Security=False";
                    var cs2 =
                        "server=(localdb)\\MSSQLLocalDB;Database=Phonebook;Integrated Security=true;MultipleActiveResultSets=true";
                    o.UseSqlServer(cs2);
                }
            });
            services.AddTransient<DbContext, PhoneBookDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IQuery, Query>();
            services.AddTransient<IContactDataProvider, ContactDataProvider>();

            services.AddTransient<IContactsService, ContactsService>();
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
