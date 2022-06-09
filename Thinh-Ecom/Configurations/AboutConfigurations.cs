
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class AboutConfigurations : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("About");
            builder.HasKey(t => new { t.about_id });

            builder.HasOne(t => t.AppUser).WithMany(ur => ur.AboutU)
     .HasForeignKey(pc => pc.about_AppUserFK);

        }
    }
}
