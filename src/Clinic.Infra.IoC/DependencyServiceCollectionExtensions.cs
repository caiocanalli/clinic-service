using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infra.IoC
{
    public static class DependencyServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            ApplicationDependencyModule.RegisterDependencies(services);
            AutoMapperDependencyModule.RegisterDependencies(services);
            DataDependencyModule.RegisterDependencies(services);
        }
    }
}