using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GillianDunneCA2._2.Startup))]
namespace GillianDunneCA2._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
