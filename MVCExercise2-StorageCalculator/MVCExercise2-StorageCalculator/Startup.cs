using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCExercise2_StorageCalculator.Startup))]
namespace MVCExercise2_StorageCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
