using DsiCodetech.Administrador.Business;
using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace DsiCodetech.Administrador.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IRegimenFiscalBusiness, RegimenFiscalBusiness>();
            container.RegisterType<IExportacionBusiness, ExportacionBusiness>();
            container.RegisterType<ITipoComprobanteBusiness,TipoComprobanteBusiness> ();
            container.RegisterType<ITipoRelacionBusiness, TipoRelacionBusiness>();
            container.RegisterType<IMetodoPagoBusiness,MetodoPagoBusiness> ();
            container.RegisterType<IFormaPagoBusiness, FormaPagoBusiness>();
            container.RegisterType<IClaveProductoServiciosBusiness,ClaveProductoServiciosBusiness>();
            container.RegisterType<IPeriocidadBusiness,PeriocidadBusiness>();
            container.RegisterType<IUsoCfdiBusiness, UsoCfdiBusiness>();
            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
        }
    }
}