using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop2.Mapping
{
    public class ProductsMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p=>p.ID);
            builder.HasQueryFilter(p=> p.Isdeleted!=true);
            builder.Property(p=>p.Count).IsRequired().HasMaxLength(3);
            builder.Property(p=>p.Description).HasMaxLength(500).IsRequired(false).HasDefaultValue("");
            builder.Property(p=>p.FPrice).IsRequired().HasMaxLength(10);
            builder.Property(p=>p.Isdeleted).IsRequired();
            builder.Property(p=>p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.Types).IsRequired().HasMaxLength(1);
            // rel --> 1 to N
            builder.HasMany(pr=>pr.comments).WithOne(co=>co.product).HasForeignKey(key=>key.ProductID);
            builder.HasMany(pr =>pr.detailsbuy).WithOne(db=>db.product).HasForeignKey(key=>key.ProductID);
        }
    }
}