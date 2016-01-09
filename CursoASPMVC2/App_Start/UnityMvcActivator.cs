using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;

//http://haacked.com/archive/2010/05/16/three-hidden-extensibility-gems-in-asp-net-4.aspx/
//This new attribute allows you to have code run way early in the ASP.NET pipeline as an application starts up. 
//I mean way early, even before Application_Start. This happens to also be before code in your App_code folder 
//(assuming you have any code in there) has been compiled. To use this attribute, create a class library and add 
//this attribute as an assembly level attribute. A common place to add this would be in the AssemblyInfo.cs class within the Properties folder
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CursoASPMVC2.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CursoASPMVC2.App_Start.UnityWebActivator), "Shutdown")]

namespace CursoASPMVC2.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}