using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.CIE;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class Tb000002Configuration:IEntityTypeConfiguration<TB000002>
    {
        public void Configure(EntityTypeBuilder<TB000002> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PK__TB000002__Id")
                .IsClustered(true);
            builder.ToTable("TB000002");
            builder.Property(e => e.Id).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
        }
    }
}
