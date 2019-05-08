using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teste3.Startup))]
namespace Teste3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
