using Autofac;
using FacesToSmileys.Services;
using FacesToSmileys.Services.Implementations;

namespace FacesToSmileys.Dependencies
{
    /// <summary>
    /// Service dependencies module
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// Load module dependencies
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DetectionService>().As<IDetectionService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<ImageProcessingService>().As<IImageProcessingService>();
            builder.RegisterType<PhotoService>().As<IPhotoService>();
            builder.RegisterType<AnalyticSercice>().As<IAnalyticService>();
        }
    }
}
