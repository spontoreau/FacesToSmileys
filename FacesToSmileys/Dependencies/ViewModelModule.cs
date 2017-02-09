using Autofac;
using FacesToSmileys.ViewModels;

namespace FacesToSmileys.Dependencies
{
    /// <summary>
    /// ViewModel dependencies module
    /// </summary>
    public class ViewModelModule : Module
    {
        /// <summary>
        /// Load module dependencies
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TakePhotoViewModel>()
                   .OnActivated(e => e.Context.InjectUnsetProperties(e.Instance));
        }
    }
}
