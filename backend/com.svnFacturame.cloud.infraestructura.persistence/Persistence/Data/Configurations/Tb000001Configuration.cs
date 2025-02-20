using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.CIE;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class Tb000001Configuration:IEntityTypeConfiguration<TB000001>
    {
        public void Configure(EntityTypeBuilder<TB000001> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PK_TB000001_Id")
                .IsClustered(true);
            builder.ToTable("TB000001");
            builder.Property(e => e.Id).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
        }

    }
}
