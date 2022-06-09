
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class ProductInCartConfigurations : IEntityTypeConfiguration<ProductInCart>
    {
        public void Configure(EntityTypeBuilder<ProductInCart> builder)
        {
            builder.ToTable("ProductInCart");
            builder.HasKey(t => new { t.pic_CartId, t.pic_ProductId });
            builder.HasOne(t => t.ProductsPICart).WithMany(ur => ur.ProductInCartP)
     .HasForeignKey(pc => pc.pic_ProductId);
            builder.HasOne(t => t.CartPICart).WithMany(ur => ur.ProductInCartC)
     .HasForeignKey(pc => pc.pic_CartId);
           
        }
    }
}
