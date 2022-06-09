using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Thinh_Ecom.Configurations
{
    public class EmailGuestConfigurations : IEntityTypeConfiguration<EmailGuest>
    {
        public void Configure(EntityTypeBuilder<EmailGuest> builder)
        {
            builder.ToTable("EmailGuest");
            builder.HasKey(t => new { t.Id });

           

        }
    }
}
