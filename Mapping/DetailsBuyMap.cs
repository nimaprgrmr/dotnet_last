using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop2.Mapping
{
    public class DetailsBuyMap : IEntityTypeConfiguration<DetailsBuy>
    {
        public void Configure(EntityTypeBuilder<DetailsBuy> builder)
        {
            builder.ToTable(nameof(DetailsBuy));
            builder.HasKey(d=> new {d.BuyID, d.ProductID});
            builder.Property(d=>d.BuyID).ValueGeneratedNever();
            builder.Property(d=>d.ProductID).ValueGeneratedNever();
            builder.Property(d=>d.Count).IsRequired().HasMaxLength(3);
            builder.Property(d=>d.TPrice).IsRequired();
            // rel --> M to N (*:*) products to buys, using a related table like DetailsBuy
            builder.HasOne(db=>db.product).WithMany(b=>b.detailsbuy).HasForeignKey(key=>key.ProductID);
            builder.HasOne(b=>b.buy).WithMany(d =>d.detailsbuy).HasForeignKey(key=>key.BuyID);

        }
    }
}