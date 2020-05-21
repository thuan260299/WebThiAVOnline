using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteHocAVOnline.Startup))]
namespace WebsiteHocAVOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
