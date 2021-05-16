using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Memo.Startup))]
namespace Memo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
