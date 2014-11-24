using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CAPrep.Startup))]
namespace CAPrep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
