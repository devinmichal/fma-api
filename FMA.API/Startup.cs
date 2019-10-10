using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.API.Entities;
using FMA.API.Models;
using FMA.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using FMA.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;

namespace FMA.API
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
            services.AddMvc(setupAction => {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });

            services.AddDbContext<FmaContext>(options =>
           {
               var connectionString = Configuration.GetConnectionString("FmaDB");
               options.UseSqlServer(connectionString);
           });
            services.AddScoped<IFmaRepository, FmaRepository>();

            var assemblies = Assembly.Load("FMA.API");
            services.AddAutoMapper(assemblies);
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FmaContext context )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(AppBuilder => AppBuilder
                .Run( async httpContext => {
                    httpContext.Response.StatusCode = 500;
                    await httpContext.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    }
                ));
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            context.SeedDataForContext();
            app.UseMvc();
        }

    }
}
