using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop2.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(nameof(Comment));
            builder.HasKey(p=>p.ID);
            builder.Property(p=> p.Text).IsRequired().HasMaxLength(255);
            builder.Property(p=> p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p=> p.Point).IsRequired().HasDefaultValue(0);
            builder.Property(p=> p.Time).IsRequired();
            // rel -> 1 to * 
            builder.HasOne(com=>com.account).WithMany(acc=>acc.comments).HasForeignKey(key=>key.AccountID);
            // rel -> 1 * * 
            builder.HasOne(com=>com.product).WithMany(pro=>pro.comments).HasForeignKey(key=>key.ProductID);
        }
    }
}