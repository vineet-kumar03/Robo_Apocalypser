using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ROBOT_Apocalypse_DAL.Models
{
    public partial class Robot_ApocalypserContext : DbContext
    {
        public Robot_ApocalypserContext()
        {
        }

        public Robot_ApocalypserContext(DbContextOptions<Robot_ApocalypserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Survivor> Survivors { get; set; }
        public virtual DbSet<SurvivorContamination> SurvivorContaminations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Robot_Apocalypser;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Survivor)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.SurvivorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Survivor");
            });

            modelBuilder.Entity<Survivor>(entity =>
            {
                entity.ToTable("Survivor");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocationLat).HasMaxLength(50);

                entity.Property(e => e.LocationLong)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SurvivorId)
                    .HasMaxLength(50)
                    .HasColumnName("SurvivorID");
            });

            modelBuilder.Entity<SurvivorContamination>(entity =>
            {
                entity.ToTable("SurvivorContamination");

                entity.Property(e => e.ReporterSurvivorId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurvivorId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
