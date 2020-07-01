using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CustomersAPIServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            BuildWebHost(args).Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                     .ConfigureAppConfiguration(config =>
                     {
                         config.AddJsonFile("appsettings.json");
                         config.AddEnvironmentVariables();
                     })
                    .UseStartup<Startup>()
                    .UseUrls("http://localhost:9001")
                    .Build();

        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA=="));
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = signingKey,
        //        ValidateIssuer = true,
        //        ValidIssuer = "http://www.c-sharpcorner.com/members/catcher-wong",
        //        ValidateAudience = true,
        //        ValidAudience = "Catcher Wong",
        //        ValidateLifetime = true,
        //        ClockSkew = TimeSpan.Zero,
        //        RequireExpirationTime = true,
        //    };

        //    return WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .UseUrls("http://localhost:9001")
        //        .ConfigureAppConfiguration((hostingContext, config) =>
        //        {
        //            config
        //                .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //                .AddJsonFile("appsettings.json", true, true)
        //                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
        //                    true)                  
        //                .AddEnvironmentVariables();
        //        })
        //        .ConfigureServices(s =>
        //        {
        //            s.AddAuthentication(x => {
        //                //x.DefaultAuthenticateScheme = "TestKey";
        //                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //            })
        //              .AddJwtBearer("TestKey", x =>
        //              {
        //                  x.RequireHttpsMetadata = false;
        //                  x.TokenValidationParameters = tokenValidationParameters;
        //              });              

        //        })               
        //        .Build();
        //}
    }
}
