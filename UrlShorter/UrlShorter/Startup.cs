using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject;
using System.Reflection;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.Common.OwinHost;
using UrlShorter.Repository;

[assembly: OwinStartup(typeof(UrlShorter.Startup))]

namespace UrlShorter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
            app.UseWebApi(config);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IReducerRepository>().To<ReducerRepository>();
        }
    }
}
