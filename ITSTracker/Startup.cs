using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSTracker.Models;
using ITSTracker.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ITSTracker
{
    public class Startup
    {
        private AuthOptions AuthOptions;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<traccarContext>(options =>
            //{
            //    options.UseNpgsql(Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
            //});
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<IService, Service>();
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
































//services.Configure<AuthOptions>(Configuration);
//services.Configure<AuthOptions>((options) => Configuration.GetSection("AuthOptions").Bind(options));
//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddJwtBearer((options) =>
//        {
//            options.RequireHttpsMetadata = false;
//            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//            {
//                ValidateIssuer = true,
//                ValidIssuer = this.AuthOptions.Issuer,
//                ValidateAudience = true,
//                ValidAudience = AuthOptions.Audience,
//                ValidateLifetime = true,
//                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
//                ValidateIssuerSigningKey = true
//            };
//        });