using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DersaneOtomasyon.Admin.Startup))]
namespace DersaneOtomasyon.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
