using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using com.svnFacturame.cloud.domain.Entities.Bancos;
using com.svnFacturame.cloud.domain.Entities.Ciudades;
using com.svnFacturame.cloud.domain.Entities.Departamentos;
using com.svnFacturame.cloud.domain.Entities.Empresas;
using com.svnFacturame.cloud.domain.Entities.CIE;
using com.svnFacturame.cloud.domain.Entities.Facturas;
using System.Numerics;
using com.svnFacturame.cloud.domain.Entities.Menu;


namespace com.svnFacturame.cloud.infraestructura.persistence.Data
{
    public partial class asaCloud_Context : DbContext
    {
        public asaCloud_Context()
        {
        }

        public asaCloud_Context(DbContextOptions<asaCloud_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TG000001> TG000001 { get; set; }
        public virtual DbSet<TG000002> TG000002 { get; set; }
        public virtual DbSet<TG000003> TG000003 { get; set; }
        public virtual DbSet<TG000004> TG000004 { get; set; }
        public virtual DbSet<TB000001> TB000001 { get; set; }
        public virtual DbSet<TB000002> TB000002 { get; set; }
        public virtual DbSet<TB000003> TB000003 { get; set; }
        public virtual DbSet<TB000004> TB000004 { get; set; }
        public virtual DbSet<TS000001> TS000001 { get; set; }
        public virtual DbSet<TR000020> TR000020 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(asaCloud_Context).Assembly);

            modelBuilder.Entity<TS000001>()
                .HasKey(x => x.Id);
                

            modelBuilder.Entity<TB000002>()
               .HasOne(d => d._TB000001)
               .WithMany(s => s._TB000002)
               .HasForeignKey(d => d.idGrupo)
               .IsRequired(); // <--

            modelBuilder.Entity<TG000002>()
               .HasOne(d => d._TG000004)
               .WithMany(s => s._TG000002)
               .HasForeignKey(d => d.IdDeptoCiud)
               .IsRequired(); // <--

            modelBuilder.Entity<TG000003>(b =>
            {
                b.Property<decimal?>("Val_AdmonGEmpAdm").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorcEps").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorAFP").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorcCaja").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorcSena").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorcICBF").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Riesgo1").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Riesgo2").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Riesgo3").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Riesgo4").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Riesgo5").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorMoraPlanilla").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("PorMoraRecibo").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("ValorMensajeriaRecibo").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("ValorReactivacion").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("ValorRetiro").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("De4amenosde16").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("De16hasta17").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Masde17hasta18").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Masde18hasta19").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Masde19hasta20").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Mayora20").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("IBCredondeado").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("IBCresiduoMayor").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("Cotizacionredondeada").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("CotizacionresiduoMayor").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("IBCnoCaja").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("CotizacionnoCaja").HasColumnType("decimal(18,0)");
                b.Property<decimal?>("AdmoGrabada").HasColumnType("decimal(18,0)");
            });
                
        }


    }
}
