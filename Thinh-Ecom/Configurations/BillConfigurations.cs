
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bills>
    {

        public void Configure(EntityTypeBuilder<Bills> builder)
        {
            builder.ToTable("Bills");
            builder.HasKey(t => new { t.bill_Id });
            builder.HasOne(t => t.AppUserB).WithMany(ur => ur.BillsAU)
     .HasForeignKey(pc => pc.bill_UserId);



        }
    }
}
