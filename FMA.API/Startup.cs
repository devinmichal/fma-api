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
            });

            services.AddDbContext<FmaContext>(options =>
           {
               var connectionString = Configuration.GetConnectionString("FmaDB");
               options.UseSqlServer(connectionString);
           });
            services.AddScoped<IFmaRepository, FmaRepository>();
          
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

            Mapper.Initialize(
            ctg =>
            {

                ctg.CreateMap<Character, CharacterDto>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.Name))
                    .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Name))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));

                ctg.CreateMap<Nationality, NationalityDto>()
                 .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
                 .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));

                ctg.CreateMap<Occupation, OccupationDto>();

                ctg.CreateMap<Capital,CapitalDto>();

                ctg.CreateMap<Currency, CurrencyDto>();

                ctg.CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.Capital, opt => opt.MapFrom(src => src.Capital.Name))
                .ForMember(dest => dest.Govenor, opt => opt.MapFrom(src => $"{src.Governor.FirstName} {src.Governor.LastName}"))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Name))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Name));
                


            }
         );
         
           

            app.UseMvc();
        }

    }
}
