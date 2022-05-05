using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaDanielMolina.Models
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext()
        {
        }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Transaccion> Transaccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5RQ5VCN\\SQLEXPRESS;Initial Catalog=PruebaDanielMolina;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.ToTable("Transaccion");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Saldo).HasColumnType("money");

                entity.Property(e => e.IdCuenta).HasColumnType("int");

                entity.Property(e => e.IdCliente).HasColumnType("int");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
