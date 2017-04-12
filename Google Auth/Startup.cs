using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Google_Auth.Startup))]
namespace Google_Auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
