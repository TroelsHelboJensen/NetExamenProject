using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTestingMockUps.Startup))]
namespace UnitTestingMockUps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
