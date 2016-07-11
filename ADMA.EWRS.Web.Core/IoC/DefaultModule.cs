using ADMA.EWRS.Data.Models.Security;
using ADMA.EWRS.Web.Security.Claims;
using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Core.IoC
{
    public class DefaultModule : Module
    {
        //private bool _perRequest;
        //public DefaultModule(bool supportPerRequest)
        //{
        //    this._perRequest = supportPerRequest;
        //}


        protected override void Load(ContainerBuilder builder)
        {
            // Register dependencies, populate the services from the collection.
            //Lifetime see : http://docs.autofac.org/en/latest/lifetime/instance-scope.html#instance-per-request
            //Also  see : http://nblumhardt.com/2011/01/an-autofac-lifetime-primer/
            //For Core : http://docs.autofac.org/en/latest/integration/aspnetcore.html#id3

            //Murad : how it is working :: http://docs.autofac.org/en/latest/faq/per-request-scope.html
            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            //IClaimsSecurityManager, ClaimsSecurityManager
            builder.RegisterType<ClaimsSecurityManager>().As<IClaimsSecurityManager>().InstancePerLifetimeScope();
        }
    }
}
