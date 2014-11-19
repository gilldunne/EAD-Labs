using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCExercise1_CloudServiceCalculator.Startup))]
namespace MVCExercise1_CloudServiceCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
