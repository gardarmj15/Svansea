using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoooLien.Startup))]
namespace MoooLien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
