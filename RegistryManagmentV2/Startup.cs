using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistryManagmentV2.Startup))]
namespace RegistryManagmentV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
