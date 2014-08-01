using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ListingsManager.Startup))]
namespace ListingsManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
