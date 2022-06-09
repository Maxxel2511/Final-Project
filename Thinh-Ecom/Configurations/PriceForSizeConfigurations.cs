using Thinh_Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Thinh_Ecom.Configurations
{
    public class PriceForSizeConfigurations : IEntityTypeConfiguration<PriceForSize>
    {
        public void Configure(EntityTypeBuilder<PriceForSize> builder)
        {
            builder.ToTable("PriceForSize");
            builder.HasKey(t => new { t.Id });



        }
    }
}
