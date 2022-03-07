using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace crud.Models
{
    public partial class TAdminContext : DbContext
    {
        public TAdminContext()
        {
        }

        public TAdminContext(DbContextOptions<TAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TvaleCc> TvaleCcs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=TAdmin;User=SA;Password=arribaLasChivas10");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TvaleCc>(entity =>
            {
                entity.ToTable("Tvale_cc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChequeNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cheque_no");

                entity.Property(e => e.CveEmpresa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cve_empresa");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Folio)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("folio");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("motivo");

                entity.Property(e => e.NumEmp)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("num_emp");

                entity.Property(e => e.NumEmpe)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("num_empe");

                entity.Property(e => e.NumReqSol)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("num_req_sol");

                entity.Property(e => e.Saldo)
                    .HasColumnType("money")
                    .HasColumnName("saldo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
