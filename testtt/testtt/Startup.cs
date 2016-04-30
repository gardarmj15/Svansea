using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testtt.Startup))]
namespace testtt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
