using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop2.Mapping
{
    public class OthersMap : IEntityTypeConfiguration<Others>
    {
        public void Configure(EntityTypeBuilder<Others> builder)
        {
            builder.ToTable(nameof(Others));
            builder.HasKey(o=>o.AccountID);
            builder.Property(o=>o.AccountID).ValueGeneratedNever(); // add this because our key comes from Account not autogenerate. 
            builder.HasAlternateKey(o=>o.CodeNation);
            builder.Property(o=>o.CodeNation).IsRequired().HasMaxLength(10);
            builder.Property(o=>o.Sex).IsRequired().HasMaxLength(1);
            builder.Property(o=>o.Age).IsRequired();
            // rel 1 --> 1
            builder.HasOne(oth=>oth.account).WithOne(acc=>acc.other).HasForeignKey<Others>(key=>key.AccountID); // .HasPrincipalKey<Others>(princ=>princ.CodeNation)
        }
    }
}