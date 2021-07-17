using AutoMapper;
using Clinic.Application.Exams;
using Clinic.Application.Labs;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infra.IoC
{
    public static class AutoMapperDependencyModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ExamMapper());
                mc.AddProfile(new LabMapper());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}