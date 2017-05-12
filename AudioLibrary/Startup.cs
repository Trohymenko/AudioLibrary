using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AudioLibrary.Startup))]
namespace AudioLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
