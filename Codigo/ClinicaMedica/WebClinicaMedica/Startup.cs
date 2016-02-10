using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebClinicaMedica.Startup))]
namespace WebClinicaMedica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
