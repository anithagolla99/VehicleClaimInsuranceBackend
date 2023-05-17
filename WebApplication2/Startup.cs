﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using VICMAPI.Models;
using VICMAPI.Service;

namespace WebApplication2
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
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddDbContext<VICMS_81258Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new Info { Title = "You api title", Version = "v1" });

                c.AddSecurityDefinition("Bearer",

                new ApiKeyScheme

                {

                    In = "header",

                    Description = "Please enter into field the word 'Bearer' following by space and JWT",

                    Name = "Authorization",

                    Type = "apiKey"

                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {

                { "Bearer", Enumerable.Empty<string>() },

                });
            });

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITokenGeneration, TokenGeneration>();
            services.AddAuthentication();

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
                app.UseHsts();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
          
            app.UseMvc();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "A API v1");
            });
            
        }
    }

    public class OpenInfo:Info
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }


    }
}
