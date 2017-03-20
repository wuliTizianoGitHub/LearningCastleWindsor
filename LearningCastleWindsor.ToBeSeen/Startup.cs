using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningCastleWindsor.ToBeSeen.Startup))]
namespace LearningCastleWindsor.ToBeSeen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
