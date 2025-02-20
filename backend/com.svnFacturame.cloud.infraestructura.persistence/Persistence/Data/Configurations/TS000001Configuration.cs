using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.Menu;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class TS000001Configuration : IEntityTypeConfiguration<TS000001> {
        public void Configure(EntityTypeBuilder<TS000001> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PK_TS000001_Id")
                .IsClustered(true);
            builder.ToTable("TS000001");
            builder.Property(e => e.Id).IsUnicode(false);
        }
    }
}
