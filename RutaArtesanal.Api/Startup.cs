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
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RutaArtesanal.Infrastructure.Repositories;
using QueryApi.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using QueryApi.Infrastructure.Validators;
using QueryApi.Domain.Dtos.Response;
using QueryApi.Domain.Dtos.Requests;
using FluentValidation;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;
using RutaArtesanal.Domain.Context;

namespace RutaArtesanal.Api
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
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RutaArtesanal.Api", Version = "v1" });
            });
            
            services.AddDbContext<RUTAARTESANALAPIContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("RutaArtesanal")));
               
           
            services.AddTransient<IArtesanoRepository, ArtesanosSQLRepository>();
            services.AddTransient<IArtesaniaRepository, ArtesaniaSQLRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IValidator<ArtesanoCreateRequest>, ArtesanoCreateRequestValidator>();
            services.AddScoped<IValidator<ArtesaniaCreateRequest>, ArtesaniaCreateRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RutaArtesanal.Api v1"));
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
