using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;

namespace ShoppingKart.Tests.IoC
{
    public class IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        private IContainer container;

        public IoCSupportedTest()
        {
            Build();
        }

        private void Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected TEntity Resolve<TEntity>()
        {
            if (container == null)
                Build();

            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
        }
    }
}
