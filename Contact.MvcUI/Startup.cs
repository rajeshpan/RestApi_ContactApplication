using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contact.MvcUI.Startup))]
namespace Contact.MvcUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
