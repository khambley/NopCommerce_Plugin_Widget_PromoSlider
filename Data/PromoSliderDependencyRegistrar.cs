using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Mvc;
using Nop.Data;
using Autofac.Core;
using Nop.Plugin.Widget.PromoSlider.Domain;
using Nop.Core.Data;

namespace Nop.Plugin.Widget.PromoSlider.Data
{
    public class PromoSliderDependencyRegistrar : IDependencyRegistrar
    {
        //added this field constant
        private const string CONTEXT_NAME = "nop_object_context_promo_slider";
        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            this.RegisterPluginDataContext<PromoSliderObjectContext>(builder, CONTEXT_NAME);

            //EfRepository is the generic repository
            builder.RegisterType<EfRepository<PromoSliderRecord>>()
                //IRepository is the abstract contract we want our data access to adhere to - NopCommerce
                .As<IRepository<PromoSliderRecord>>()
                //Autofac method
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<PromoImageRecord>>()
                .As<IRepository<PromoImageRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
        }
    }
}
