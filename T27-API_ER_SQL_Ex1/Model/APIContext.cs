using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace T27_API_ER_SQL_Ex1.Model
{
    public class APIContext : DbContext
    {
        // IMPORTAMOS LAS OPCIONES DE DbContext
        public APIContext(DbContextOptions<APIContext> options) : base(options) {}

        // ATRIBUTOS, GETTERS Y SETTERS
        public virtual DbSet<Pieza> Pieza { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }

        //DEFINIMOS LOS MODELOS DE LA BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieza>(pieza =>
            {
                // NOMBRE TABLA
                pieza.ToTable("PIEZAS");

                // PROPIEDADES DE COLUMNAS
                pieza.Property(e => e.Codigo).HasColumnName("Codigo");
                pieza.HasKey(e => e.Codigo);

                pieza.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);            
            });

            modelBuilder.Entity<Proveedor>(proveedor =>
            {
                // NOMBRE TABLA
                proveedor.ToTable("PROVEEDORES");

                // PROPIEDADES DE COLUMNAS
                proveedor.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                proveedor.HasKey(e => e.Id);

                proveedor.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);                 
            });

            modelBuilder.Entity<Suministra>(suministra => 
            {
                // NOMBRE TABLA
                suministra.ToTable("SUMINISTRA");

                // PROPIEDADES DE COLUMNAS
                suministra.Property(e => e.CodigoPieza).HasColumnName("CodigoPieza");
                suministra.HasKey(e => e.CodigoPieza);

                suministra.Property(e => e.IdProveedor)
                    .HasColumnName("IdProveedor")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                suministra.HasKey(e => e.IdProveedor);

                suministra.Property(e => e.Precio).HasColumnName("Precio");

                // RELACIONES
                suministra.HasOne(r => r.Pieza)
                    .WithMany(m => m.Suministros)
                    .HasForeignKey(e => e.CodigoPieza)
                    .HasConstraintName("CodigoPieza_fk");

                suministra.HasOne(r => r.Proveedor)
                    .WithMany(m => m.Suministros)
                    .HasForeignKey(e => e.IdProveedor)
                    .HasConstraintName("IdProveedor_fk");
            });
        }
    }
}
