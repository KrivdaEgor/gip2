using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GIP2LearnPlatform.Startup))]
namespace GIP2LearnPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
