﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DersaneOtomasyon.UI.Startup))]
namespace DersaneOtomasyon.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
