using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZYW.CommonMVC;
using ZYW.IServices;

namespace ZYW.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(string), new TrimToDBCModelBinder());
            ModelBinders.Binders.Add(typeof(int), new TrimToDBCModelBinder());
            ModelBinders.Binders.Add(typeof(long), new TrimToDBCModelBinder());
            ModelBinders.Binders.Add(typeof(double), new TrimToDBCModelBinder());

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly)
                .PropertiesAutowired();//Register Controllers in the current assembly                                                                                              //不要忘了.PropertiesAutowired()
                                       // Get assemblies of all related class libraries
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            Assembly[] assemblies = new Assembly[] { Assembly.Load("ZYW.Services") };
            builder.RegisterAssemblyTypes(assemblies)
            .Where(type => !type.IsAbstract
                    && typeof(IServiceSupport).IsAssignableFrom(type))
                    .AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterWebApiModelBinderProvider();
            //Assign:
            //type1.IsAssignableFrom(type2);
            //In other words, does type2 implement the type1 interface / type2 inherit from type1?
            //Typeeof (IServiceSupport). IsAssignableFrom (type) only registers classes that implement IServiceSupport
            //Avoid registering other unrelated classes in AutoFac
            var container = builder.Build();
            //Register system-level Dependency Resolver so that when the MVC framework creates objects such as Controller, it manages Autofac objects.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);//ApiController　WebApi注入 


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
