using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.Empresas;
using com.svnFacturame.cloud.domain.Entities.Ciudades;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class Tg000003Configuration : IEntityTypeConfiguration<TG000003>
    {
        public void Configure(EntityTypeBuilder<TG000003> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PK_TG000003_Id")
                .IsClustered(true);
            builder.ToTable("TG000003");
            builder.Property(e => e.Id).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
        }
    }
}
