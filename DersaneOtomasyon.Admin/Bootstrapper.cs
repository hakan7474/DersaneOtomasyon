using Autofac;
using Autofac.Integration.Mvc;
using DersaneOtomasyon.Core.Infrastructure;
using DersaneOtomasyon.Core.Repository;
using DersaneOtomasyon.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersaneOtomasyon.Admin.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void RunConfig()
        {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var build = new ContainerBuilder();

            build.RegisterControllers(typeof(MvcApplication).Assembly) ;

           
            build.RegisterType<AlanRepository>().As<IAlanRepository>();
         
            build.RegisterType<OdemeRepository>().As<IOdemeRepository>();
            build.RegisterType<OgrenciRepository>().As<IOgrenciRepository>();
            
            build.RegisterType<VeliRepositor>().As<IVeliRepository>();


            var container = build.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}