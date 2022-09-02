using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Business.Abstract;
using TaskCoreAPI.Business.Concrete;
using TaskCoreAPI.Data.Abstract;
using TaskCoreAPI.Data.Concrete.EfCore;
using TaskCoreAPI.Data.Concrete.TaskCoreAPIContext;
using TaskCoreAPI.WebUI.DBContext;
using TaskCoreAPI.WebUI.IdentityAuth;

namespace TaskCoreAPI
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("MyWebApiConnection")));
          //  services.AddSwaggerGen(swagger =>
          //  {
          //      //This is to generate the Default UI of Swagger Documentation
          //      swagger.SwaggerDoc("v1", new OpenApiInfo
          //      {
          //          Version = "v1",
          //          Title = "TaskCoreAPI",
          //          Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
          //      });
          //      // To Enable authorization using Swagger (JWT)
          //      swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
          //      {
          //          Name = "Authorization",
          //          Type = SecuritySchemeType.ApiKey,
          //          Scheme = "Bearer",
          //          BearerFormat = "JWT",
          //          In = ParameterLocation.Header,
          //          Description = "Enter ‘Bearer’ [space] and then your valid token in the text input below.\r\n\r\nExample: \\”Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
          //    });
          //          swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
          //  {
          //{
          //           new OpenApiSecurityScheme
          //  {
          //           Reference = new OpenApiReference
          //        {
          //            Type = ReferenceType.SecurityScheme,
          //            Id = "Bearer"
          // }
          //  },
          //    new string[] {}

          //  }
          //  });
          //  });
            // For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIApplication", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Please provide authorization token to access restricted features.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
            });
           
            //services.AddSingleton<IConfiguration>(Configuration);
            services.AddMvc();

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();


            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskCoreAPI v1"));
            }

            app.UseHttpsRedirection();

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