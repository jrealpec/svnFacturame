using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.Facturas;

namespace com.svnFacturame.cloud.infraestructura.persistence.Persistence.Data.Configurations
{
    public class TR000020Configuration
    {
        public void Configure(EntityTypeBuilder<TR000020> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PK_TR000020_Id")
                .IsClustered(true);
            builder.ToTable("TR000020");
            builder.Property(e => e.Id).IsUnicode(false);
        }
    }
}
