using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.DependencyResolution;
using StructureMap;
using System.Web.Http;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.StructuremapMvc), "Start")]

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            IContainer container = IoC.Initialize();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}