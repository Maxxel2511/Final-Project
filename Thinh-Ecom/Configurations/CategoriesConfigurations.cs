
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class CategoriesConfigurations : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(t => new { t.cg_Id });
        }
    }
}
