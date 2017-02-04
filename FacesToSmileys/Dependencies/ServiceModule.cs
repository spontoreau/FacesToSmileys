using Autofac;
using FacesToSmileys.Services;
using FacesToSmileys.Services.Implementations;

namespace FacesToSmileys.Dependencies
{
    public class ServiceModule : Module
    {
        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DetectionService>().As<IDetectionService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<ImageProcessingService>().As<IImageProcessingService>();
            builder.RegisterType<PhotoService>().As<IPhotoService>();
        }
    }
}
