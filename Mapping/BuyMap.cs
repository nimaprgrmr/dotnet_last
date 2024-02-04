using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Eshop2.Mapping
{
    public class BuyMap : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.ToTable(nameof(Buy));
            builder.HasKey(b=>b.ID);
            builder.Property(b=>b.Description).HasMaxLength(500).IsRequired(false).HasDefaultValue("");
            builder.Property(b=>b.Time).IsRequired();
            // rel --> 1 to * 
            builder.HasOne(bu=>bu.account).WithMany(acc=>acc.buys).HasForeignKey(key=>key.AccountID);
            builder.HasMany(b=>b.detailsbuy).WithOne(db=>db.buy).HasForeignKey(Key=>Key.BuyID);
        }
    }
}