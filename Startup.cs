using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UserRegistrationSample.Startup))]

namespace UserRegistrationSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
