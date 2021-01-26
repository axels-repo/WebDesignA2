using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_12246765_OnlineStore.Startup))]
namespace _12246765_OnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
