using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthCode.Startup))]
namespace AuthCode
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
