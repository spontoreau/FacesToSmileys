using Autofac;
using FacesToSmileys.ViewModels;

namespace FacesToSmileys.Dependencies
{
    public class ViewModelModule : Module
    {
        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<TakePhotoViewModel>()
                   .OnActivated(e => e.Context.InjectUnsetProperties(e.Instance));
        }
    }
}
