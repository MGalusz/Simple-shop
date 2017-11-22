using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
//using Hangfire;

namespace Simple_shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

           // GlobalConfiguration.Configuration.UseSqlServerStorage("KursyContext");
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
        }
    }
}