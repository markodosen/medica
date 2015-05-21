using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medica.Startup))]
namespace Medica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
