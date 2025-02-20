using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.Ciudades;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class Tg000002Configuration : IEntityTypeConfiguration<TG000002>
    {
        public void Configure(EntityTypeBuilder<TG000002> builder)
        {
            
            builder.HasKey(e => e.Id)
                .HasName("PK_TG000002_Id")
                .IsClustered(true);
            builder.ToTable("TG000002");
            builder.Property(e => e.Id).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
        }
        
    }
}
