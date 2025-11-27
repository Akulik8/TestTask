using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Models;

namespace TestTask.Data.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Make).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Model).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Year).IsRequired();
            builder.Property(e => e.Color).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.FuelType).HasMaxLength(20).IsRequired();
        }
    }
}
