using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentDemo.Startup))]
namespace AssignmentDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
