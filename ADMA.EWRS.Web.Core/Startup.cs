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
using ADMA.EWRS.Web.Security.Claims;
using ADMA.EWRS.Web.Security;
using ADMA.EWRS.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using ADMA.EWRS.Web.Security.Policy;
using ADMA.EWRS.Data.Models.Security;
using Autofac;
using Autofac.Extensions.DependencyInjection;

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
                //Murad : TODO : Add it later 
               //builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Murad : When using a third-party DI container, you must change ConfigureServices so that it returns IServiceProvider instead of void.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //Murad :: Add Security
            services.AddAuthorization(options =>
            {
                PoliciesManager.BuildSystemPolicies(options);
            });

            services.AddSession();

            // Murad Add this for RC2, remove it if release 1.0 after June :: AddRazorOptions
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .RequireRole(Groups.ADMAUserGroupName)
                                 .Build();

                // to be added
                //config.Filters.Add(new AuthorizeFilter(GlobalExceptionFilter));

                config.Filters.Add(new AuthorizeFilter(policy));

                //Murad :: Info : https://damienbod.com/2015/09/15/asp-net-5-action-filters/
                config.Filters.Add(new Filters.AppFilter());


            });
            /*
             * Murad :: BUG Fixed 
            ).AddRazorOptions(options =>
            {
                var previous = options.CompilationCallback;
                options.CompilationCallback = context =>
                {
                    previous?.Invoke(context);
                    context.Compilation = context.Compilation.AddReferences(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(typeof(ADMA.EWRS.Data.Models.Murad).Assembly.Location));
                };
            });
            */

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


            //Murad : Replace ASP.NET Core DI with better AutoFac
            //services.AddScoped<IClaimsSecurityManager, ClaimsSecurityManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Murad :: Add IoC i used AutoFac
            //Check : http://docs.autofac.org/en/latest/integration/aspnetcore.html

            // Add Autofac
            // Create the container builder.
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterModule<IoC.DefaultModule>();

            //using Autofac.Extensions.DependencyInjection; it is extension method 
            containerBuilder.Populate(services);

            //build the container
            var container = containerBuilder.Build();

            // Return the IServiceProvider resolved from the container.
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //Murad :: Replace in future with Cache Manager 
            app.UseSession(
                new SessionOptions()
                {
                    CookieName = Cookies.SessionsCookieName,
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
                AuthenticationScheme = Cookies.AuthenticationCookieName,
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
