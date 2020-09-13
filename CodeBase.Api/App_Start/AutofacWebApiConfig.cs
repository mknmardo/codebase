using Autofac;
using Autofac.Integration.WebApi;
using CodeBase.Cache;
using CodeBase.Infrastructure;
using CodeBase.Repositories;
using CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CodeBase.Api.App_Start
{
    public class AutofacWebApiConfig
    {
        public static IContainer container;

        public static IContainer Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();
            builder.RegisterGeneric(typeof(GenericRepository<>));

            builder.RegisterGeneric(typeof(MemCache<>)).As(typeof(IMemCache<>));

            builder.RegisterType<SampleService>().As<ISampleService>();
            builder.RegisterType<SampleRepository>().As<ISampleRepository>();

            container = builder.Build();

            return container;
        }
    }
}