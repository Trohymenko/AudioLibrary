using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AudioLibraryView.Startup))]
namespace AudioLibraryView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
