using System;
using System.Collections.Generic;
using System.IO;
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
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    BuildWebHost(args).Run();
        //}
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
        //        .UseUrls("http://localhost:9000")
        //        .ConfigureAppConfiguration((hostingContext, config) =>
        //        {
        //            config
        //                .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //                .AddJsonFile("appsettings.json", true, true)
        //                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
        //                    true)
        //                .AddJsonFile("ocelot.json", false, false)
        //                .AddEnvironmentVariables();
        //        })
        //        .ConfigureServices(s =>
        //        {                   

        //            s.AddAuthentication(x => { 
        //                x.DefaultAuthenticateScheme = "TestKey";
        //                x.DefaultChallengeScheme = "TestKey";
        //            })
        //              .AddJwtBearer("TestKey", x =>
        //              {
        //                  x.RequireHttpsMetadata = false;
        //                  x.TokenValidationParameters = tokenValidationParameters;
        //              });

        //            s.AddOcelot();
        //            //.AddEureka().AddCacheManager(x => x.WithDictionaryHandle());
        //        })
        //        .Configure(a =>
        //        {
        //            // var appSettings = new AppSettings();
        //            //a.ApplicationServices.GetService<IConfiguration>()
        //            //    .GetSection("Audience");
        //                //.Bind(appSettings);

        //            //a.UseCors
        //            //(b => b
        //            //    .WithOrigins(appSettings.AllowedChatOrigins)
        //            //    .AllowAnyMethod()
        //            //    .AllowAnyHeader()
        //            //    .AllowCredentials()
        //            //);
        //            a.UseOcelot().Wait();

        //        })
        //        .Build();
        //}

        //public static void Main(string[] args)
        //{
        //    new WebHostBuilder()
        //    .UseKestrel()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config
        //            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //            .AddJsonFile("appsettings.json", true, true)
        //            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
        //            .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
        //            .AddEnvironmentVariables();
        //    })
        //    .ConfigureServices(s =>
        //    {
        //        s.AddOcelot();
        //    })
        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //       // add your logging
        //    })
        //    .UseIISIntegration()
        //    .UseUrls("http://localhost:9000")
        //    .Configure(app =>
        //    {
        //        app.UseOcelot().Wait();
        //    })
        //    .Build()
        //    .Run();
        //}
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        })

        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config
        //            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //            .AddJsonFile("ocelot.json", false, true)
        //            .AddEnvironmentVariables();
        //    });
        public static void Main(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });
            builder.UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            })
                   .UseStartup<Startup>()
                   .UseUrls("http://localhost:9000");

            var host = builder.Build();
            host.Run();
        }
    }
}
