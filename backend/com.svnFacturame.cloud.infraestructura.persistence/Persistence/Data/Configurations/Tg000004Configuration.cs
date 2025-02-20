using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.Departamentos;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class Tg000004Configuration : IEntityTypeConfiguration<TG000004>
    {
        public void Configure(EntityTypeBuilder<TG000004> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PK_TG000004_Id")
                .IsClustered(true);
            builder.ToTable("TG000004");
            builder.Property(e => e.Id).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
        }
    }
}
