using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace  LoginMVC.Models
{
    public partial class appsContext : DbContext
    {
        public appsContext()
        {
        }

        public appsContext(DbContextOptions<appsContext> options)
            : base(options)
        {
        }

        
     public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=apps;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Idrol);

                entity.ToTable("roles");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Idusuarios).HasColumnName("idusuarios");

                entity.Property(e => e.Nombrerol)
                    .HasColumnName("nombrerol")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdusuariosNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.Idusuarios)
                    .HasConstraintName("roles_idusuarios_fkey");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Userid)
                    .HasName("usuarios_userid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(50);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(50);
            });
        }
    }
}
