using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CST465.Startup))]
namespace CST465
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}