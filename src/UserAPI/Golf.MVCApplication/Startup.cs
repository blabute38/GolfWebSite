using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Golf.MVCApplication.Startup))]
namespace Golf.MVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
