using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Moolien.Startup))]
namespace Moolien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
