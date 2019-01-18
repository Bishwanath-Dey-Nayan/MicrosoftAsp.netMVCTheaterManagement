using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PLTheater.Startup))]
namespace PLTheater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
