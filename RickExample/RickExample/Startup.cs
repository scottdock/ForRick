using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RickExample.Startup))]
namespace RickExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
