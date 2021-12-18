using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(20,2)");
            builder.Property(p => p.Image).IsRequired();
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
            builder.HasOne(t => t.Category).WithMany().HasForeignKey(p => p.CategoryId);
        }
    }
}