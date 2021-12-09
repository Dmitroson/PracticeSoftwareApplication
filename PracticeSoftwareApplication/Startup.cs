using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeSoftwareApplication.Startup))]
namespace PracticeSoftwareApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
