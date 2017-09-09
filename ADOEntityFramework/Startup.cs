using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADOEntityFramework.Startup))]
namespace ADOEntityFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
