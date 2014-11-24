using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CAPrep2.Startup))]
namespace CAPrep2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
