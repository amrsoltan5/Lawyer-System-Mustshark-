using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Faculty.Startup))]
namespace Project_Faculty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
