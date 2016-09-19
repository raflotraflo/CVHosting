using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVHosting.Startup))]
namespace CVHosting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
