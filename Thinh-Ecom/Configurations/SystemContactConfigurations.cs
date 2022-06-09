
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class SystemContactConfigurations : IEntityTypeConfiguration<SystemContact>
    {
        public void Configure(EntityTypeBuilder<SystemContact> builder)
        {
            builder.ToTable("ContactSystems");
            builder.HasKey(t => new { t.Contact_Id });

            builder.HasOne(t => t.AppUser).WithMany(ur => ur.SystemContactU)
.HasForeignKey(pc => pc.Contact_AppUserFK);
        }
    }
}
