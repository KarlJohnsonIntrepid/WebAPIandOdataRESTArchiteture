using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Lead.WebAPI.Startup))]

namespace Lead.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
