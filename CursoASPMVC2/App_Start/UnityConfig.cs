using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CursoASPMVC2.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            //string _connectionString = @"metadata=res://*/CursoModel.csdl|res://*/CursoModel.ssdl|res://*/CursoModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=VAIO\SQLEXPRESS;initial catalog=CursoASPMVC;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            
            //string _connectionString = @"metadata=res://*/CursoModel.csdl|res://*/CursoModel.ssdl|res://*/CursoModel.msl;provider=System.Data.SqlClient;provider connection string="";data source=VAIO\SQLEXPRESS;initial catalog=CursoASPMVC;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"";";
            //container.RegisterType<System.Data.Entity.DbContext, CursoASPMVC2.Domain.CursoASPMVCEntities>(new PerRequestLifetimeManager(), new InjectionConstructor(_connectionString));
            //container.RegisterType<System.Data.Entity.DbContext, System.Data.Entity.DbContext>(new PerRequestLifetimeManager(), new InjectionConstructor(_connectionString));
            //container.RegisterType<System.Data.Entity.DbContext>(new PerRequestLifetimeManager(), new InjectionConstructor(_connectionString));

            container.RegisterType<System.Data.Entity.DbContext, CursoASPMVC2.Domain.CursoASPMVCEntities>(new PerRequestLifetimeManager());
            container.RegisterType<CursoASPMVC2.Domain.Contracts.ICompanyRepository, CursoASPMVC2.Data.Repository.CompanyRepository>(new PerRequestLifetimeManager());
            container.RegisterType<CursoASPMVC2.Service.IAppService, CursoASPMVC2.Service.AppService>(new PerRequestLifetimeManager());

            //Unit of work
            container.RegisterType<CursoASPMVC2.Domain.Contracts.ICompanyUoW, CursoASPMVC2.Data.Repository.CompanyUoW>(new PerRequestLifetimeManager());
            container.RegisterType(typeof(Domain.Contracts.IRepository<>), typeof(Data.Repository.Repository<>));
        }
    }
}
