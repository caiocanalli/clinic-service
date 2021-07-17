using Clinic.Application.Exams.Validators;
using Clinic.Infra.Data;
using Clinic.Infra.IoC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Clinic.Services.Api
{
    public class Startup
    {
        const string AllowOriginPolicy = "AllowOrigin";

        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Information($"Checking configurations");
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                Log.Information($"{key}: {value}");
            }
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<UpdateRequestValidator>());

            services.AddHealthChecks();

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Clinic.Services.Api", Version = "v1"});
            });

            services.AddCors(options =>
            {
                options.AddPolicy(AllowOriginPolicy,
                    builder =>
                    {
                        builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithOrigins("http://localhost:4200")
                            .WithOrigins("http://localhost:8080");
                    });
            });

            services.RegisterDependencies();

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ConnectionString")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                context.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic.Services.Api v1"));
            }

            app.UseRouting();

            app.UseCors(AllowOriginPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/api/health");
            });
        }
    }
}