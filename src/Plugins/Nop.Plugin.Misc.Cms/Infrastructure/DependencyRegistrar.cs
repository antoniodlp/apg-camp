using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Infrastructure;
using SoapTest;

namespace Nop.Plugin.Widgets.Sandbox.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {

            builder.RegisterType<Nop.Plugin.Misc.Cms.Areas.Admin.Controllers.CmsTopicController>()
                .As<Nop.Web.Areas.Admin.Controllers.TopicController>().InstancePerLifetimeScope();

            builder.RegisterType<Nop.Plugin.Misc.Cms.Controllers.CmsTopicController>()
                .As<Nop.Web.Controllers.TopicController>().InstancePerLifetimeScope();

            //data context

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 100; }
        }
    }
}
