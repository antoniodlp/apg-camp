using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Widgets.Sandbox.Data;
using Nop.Plugin.Widgets.Sandbox.Domain;
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

            const string dataContextName = "nop_object_context_sandbox";

            //data context
            this.RegisterPluginDataContext<SandboxObjectContext>(builder, dataContextName);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<SandboxPrescription>>()
                .As<IRepository<SandboxPrescription>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(dataContextName))
                .InstancePerLifetimeScope();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<SandboxPrescriptionItem>>()
                .As<IRepository<SandboxPrescriptionItem>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(dataContextName))
                .InstancePerLifetimeScope();

            builder.RegisterType<CartClient>()
                .As<CartClient>()
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
