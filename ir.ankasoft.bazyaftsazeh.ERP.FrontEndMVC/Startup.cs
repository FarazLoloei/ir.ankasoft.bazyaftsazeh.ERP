using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Startup))]

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}