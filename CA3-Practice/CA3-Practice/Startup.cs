using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA3_Practice.Startup))]
namespace CA3_Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
