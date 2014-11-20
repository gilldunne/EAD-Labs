using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab1_Welcome.Startup))]
namespace Lab1_Welcome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
