
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class CouponsConfigurations : IEntityTypeConfiguration<Coupons>
    {
        public void Configure(EntityTypeBuilder<Coupons> builder)
        {
            builder.ToTable("Coupons");
            builder.HasKey(t => new { t.couponId });


            builder.HasOne(t => t.AppUser).WithMany(ur => ur.CouponsU)
     .HasForeignKey(pc => pc.coupon_AppUserFK);
        }

    }
}
