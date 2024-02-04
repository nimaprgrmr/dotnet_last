using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;

namespace Eshop2.Mapping
{
    public class Accountmap: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.HasKey(a=> a.ID);
            builder.HasAlternateKey(a=>a.Username);
            builder.HasQueryFilter(a=>a.PostCode>0);
            builder.Property(a=> a.Address).IsRequired().HasMaxLength(500);
            builder.Property(a=> a.City).IsRequired().HasMaxLength(50);
            builder.Property(a=> a.Email).IsRequired().HasMaxLength(200);
            builder.Property(a=> a.NameFamily).IsRequired().HasMaxLength(250);
            builder.Property(a=> a.Password).IsRequired().HasMaxLength(50);
            builder.Property(a=> a.PhoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(a=> a.PostCode).IsRequired().HasMaxLength(10);
            var point = new Point(0.0, 0.0);
            point.SRID = 4326; // this is the default value for 0, 0  (X & y) values 
            builder.Property(a=> a.Location).IsRequired(false).HasDefaultValue(point);
            // rel ---> 1 to 1
            builder.HasOne(acc => acc.other).WithOne(oth=>oth.account).HasForeignKey<Others>(key=>key.AccountID);
            // rel ---> 1 to * 
            builder.HasMany(acc => acc.comments).WithOne(com => com.account).HasForeignKey(key => key.AccountID);
            builder.HasMany(acc => acc.buys).WithOne(bu => bu.account).HasForeignKey(key=>key.AccountID);
         }
    }
}
