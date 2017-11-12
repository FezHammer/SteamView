using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SteamView.Startup))]
namespace SteamView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
