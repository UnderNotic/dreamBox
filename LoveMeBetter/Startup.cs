using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoveMeBetter.Startup))]
namespace LoveMeBetter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
