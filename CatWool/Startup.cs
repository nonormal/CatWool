using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatWool.Startup))]
namespace CatWool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
