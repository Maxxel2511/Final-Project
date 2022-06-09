
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class ShippingConfigurations : IEntityTypeConfiguration<Shipping>
    {

        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.ToTable("Shipping");
            builder.HasKey(t => new { t.ship_Id });


            builder.HasOne(t => t.AppUser).WithMany(ur => ur.ShippingU)
.HasForeignKey(pc => pc.ship_AppUserFK);
        }
    }
}
