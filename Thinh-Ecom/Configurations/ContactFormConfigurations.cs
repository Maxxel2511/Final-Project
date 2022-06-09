
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thinh_Ecom.Configurations
{
    public class ContactFormConfigurations : IEntityTypeConfiguration<ContactForm>
    {
        public void Configure(EntityTypeBuilder<ContactForm> builder)
        {
            builder.ToTable("ContactUsers");
            builder.HasKey(t => new { t.cf_Id });
        }
    }
}
