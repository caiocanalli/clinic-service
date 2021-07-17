using Clinic.Application.Exams;
using Clinic.Application.Labs;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infra.IoC
{
    public static class ApplicationDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IExamAppService, ExamAppService>();
            services.AddScoped<ILabAppService, LabAppService>();
        }
    }
}