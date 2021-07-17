using Clinic.Domain.Common;
using Clinic.Domain.Exams;
using Clinic.Domain.Labs;
using Clinic.Infra.Data;
using Clinic.Infra.Data.Exams;
using Clinic.Infra.Data.Labs;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infra.IoC
{
    public static class DataDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<ILabRepository, LabRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<Context>();
        }
    }
}