using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA3_SampleWork.Startup))]
namespace CA3_SampleWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
