﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guitarServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace guitarServer
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

            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>(
                e => Configuration.GetSection("ApplicationConfiguration")
                    .Get<ApplicationConfiguration>());
           
            services.AddCors(options =>{
                options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins("https://www.guitarpricer.site","https://guitarpricer.site","http://localhost:5000","http://localhost:8080","http://127.0.0.1:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
                });
                
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("https://www.guitarpricer.site","https://guitarpricer.site","http://localhost:5000","http://localhost:8080","http:127.0.0.1:5000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()   
            );

            app.UseMvc();
        }
        
    }
}
