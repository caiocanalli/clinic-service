using System.Collections.Generic;
using Clinic.Domain.Exams;
using Clinic.Domain.Labs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Status = Clinic.Domain.Labs.Status;

namespace Clinic.Infra.Data.Labs
{
    sealed class LabMapping : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder
                .ToTable("Lab");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(x => x.Address)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("tinyint")
                .HasConversion(new EnumToNumberConverter<Status, byte>())
                .IsRequired();

            builder
                .HasMany(x => x.Exams)
                .WithMany(x => x.Labs)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamLab",
                    b => b.HasOne<Exam>().WithMany().HasForeignKey("ExamId"),
                    b => b.HasOne<Lab>().WithMany().HasForeignKey("LabId"));
        }
    }
}