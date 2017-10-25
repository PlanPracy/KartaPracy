using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KartaPracy.Startup))]
namespace KartaPracy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
