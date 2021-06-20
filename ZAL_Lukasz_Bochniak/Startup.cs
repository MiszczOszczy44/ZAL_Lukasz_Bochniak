using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZAL_Lukasz_Bochniak.Startup))]
namespace ZAL_Lukasz_Bochniak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
