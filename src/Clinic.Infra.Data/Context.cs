using Clinic.Infra.Data.Exams;
using Clinic.Infra.Data.Labs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Clinic.Infra.Data
{
    public class Context : DbContext
    {
        readonly IConfiguration _configuration;
        
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExamMapping());
            modelBuilder.ApplyConfiguration(new LabMapping());
        }
    }
}