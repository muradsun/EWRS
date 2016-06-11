using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using ADMA.EWRS.Web.Security.Policy;
using ADMA.EWRS.Web.Security.Claims;
using ADMA.EWRS.Web.Security;

namespace ADMA.EWRS.Web.Core
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            //Murad :: Add Security
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.SuperAdministrators,
                    policy => policy.RequireRole("Administrator"));

                //options.AddPolicy(PolicyNames.CanEditProject,
                //    policy =>
                //    {
                //        policy.RequireAuthenticatedUser();
                //        policy.RequireRole("Administrator");
                //        policy.Requirements.Add(new ProjectOwnerRequirement());
                //    }
                //);
            });

            services.AddSession();
            services.AddMvc().// Murad Add this for RC2, remove it if release 1.0 after June 
                AddRazorOptions(options =>
            {
                var previous = options.CompilationCallback;
                options.CompilationCallback = context =>
                {
                    previous?.Invoke(context);
                    context.Compilation = context.Compilation.AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(typeof(ADMA.EWRS.Data.Models.Murad).Assembly.Location));
                };
            });

            //var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Select(x => Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(x.Location)).ToList();
            //services.Configure((Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions options) =>
            //{
            //    var previous = options.CompilationCallback;
            //    options.CompilationCallback = (context) =>
            //    {
            //        previous?.Invoke(context);

            //        context.Compilation = context.Compilation.AddReferences(myAssemblies);
            //    };
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();
            app.UseStaticFiles();

            //Murad :: Replace in future with Cache Manager 
            app.UseSession(
                new SessionOptions()
                {
                    CookieName = "ADMA.EWRS.Session",
                    IdleTimeout = TimeSpan.FromMinutes(60)
                });

            //app.Map("/session", subApp =>
            //{
            //    subApp.Run(async context =>
            //    {
            //        int visits = 0;
            //        visits = context.Session.GetInt32("visits") ?? 0;
            //        context.Session.SetInt32("visits", ++visits);
            //        await context.Response.WriteAsync("Counting: You have visited our page this many times: " + visits);
            //    });
            //});

            //HttpContext.Session.SetString("Name", "Mike");

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = ClaimConstants.MiddlewareScheme,
                LoginPath = new PathString("/Account/Login/"),
                AccessDeniedPath = new PathString("/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                SessionStore = new MemoryCacheTicketStore()
            });

            //Murad: Build Custom ADMA Claim Provider - If Allah give us more time in those FA people
            //app.UseClaimsTransformation(new ClaimsTransformationOptions
            //{
            //    Transformer = new ADMAClaimsTransformer()
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
