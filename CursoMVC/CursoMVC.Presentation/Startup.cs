using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoMVC.Presentation.Startup))]
namespace CursoMVC.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
