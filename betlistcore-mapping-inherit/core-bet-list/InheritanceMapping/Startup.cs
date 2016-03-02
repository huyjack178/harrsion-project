using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InheritanceMapping.Startup))]
namespace InheritanceMapping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
