using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using com.svnFacturame.cloud.domain.Entities.Bancos;

namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public class Tg000001Configuration:IEntityTypeConfiguration<TG000001>
    {
        public void Configure(EntityTypeBuilder<TG000001> builder)
        {
            
            builder.HasKey(e => e.Id)
                .HasName("PK_TG000001_Id")
                .IsClustered(true);
            builder.ToTable("TG000001");
            builder.Property(e => e.CodBanco).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
        }
        
    }
}
