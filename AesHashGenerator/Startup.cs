using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AesHashGenerator.Startup))]
namespace AesHashGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
