using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catalyst.Startup))]
namespace Catalyst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
