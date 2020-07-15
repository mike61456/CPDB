using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CPD.MVC.Startup))]
namespace CPD.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
