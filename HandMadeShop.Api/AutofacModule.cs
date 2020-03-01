using Autofac;
using HandMadeShop.Api.Extensions;

namespace HandMadeShop.Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.AddProjectServices();
            builder.AddCqrsHandlers();
            builder.AddDecorators();
            builder.AddEventListeners();
        }
    }
}