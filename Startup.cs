using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ME_BlogProject.Startup))]
namespace ME_BlogProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
