using System.Collections.Generic;
using Clinic.Domain.Exams;
using Clinic.Domain.Labs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Status = Clinic.Domain.Exams.Status;

namespace Clinic.Infra.Data.Exams
{
    sealed class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder
                .ToTable("Exam");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("bigint")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnType("tinyint")
                .HasConversion(new EnumToNumberConverter<ExamType, byte>())
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("tinyint")
                .HasConversion(new EnumToNumberConverter<Status, byte>())
                .IsRequired();

            builder
                .HasMany(x => x.Labs)
                .WithMany(x => x.Exams)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamLab",
                    b => b.HasOne<Lab>().WithMany().HasForeignKey("LabId"),
                    b => b.HasOne<Exam>().WithMany().HasForeignKey("ExamId"));
        }
    }
}