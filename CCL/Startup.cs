using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCL.Startup))]
namespace CCL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
