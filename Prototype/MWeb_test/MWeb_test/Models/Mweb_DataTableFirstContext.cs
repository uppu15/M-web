using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MWeb_test.Models
{
    public partial class Mweb_DataTableFirstContext : DbContext
    {
        public Mweb_DataTableFirstContext()
        {
        }

        public Mweb_DataTableFirstContext(DbContextOptions<Mweb_DataTableFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Markers> Markers { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }
        public virtual DbSet<Userss> Userss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=Mweb_DataTableFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_Comment");

                entity.Property(e => e.CommentId).HasColumnName("commentID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.MarkerId).HasColumnName("markerID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Marker)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MarkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Marker");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Markers>(entity =>
            {
                entity.HasKey(e => e.MarkerId)
                    .HasName("PK_Marker");

                entity.Property(e => e.MarkerId).HasColumnName("markerID");

                entity.Property(e => e.MarkerLat)
                    .HasColumnName("markerLat")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.MarkerLng)
                    .HasColumnName("markerLng")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasColumnName("photoPath")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Markers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marker_User");
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK_Setting");

                entity.Property(e => e.SettingId).HasColumnName("settingID");

                entity.Property(e => e.CenterLat)
                    .HasColumnName("centerLat")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CenterLng)
                    .HasColumnName("centerLng")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CenterZoom).HasColumnName("centerZoom");

                entity.Property(e => e.Gps).HasColumnName("GPS");

                entity.Property(e => e.MapType)
                    .IsRequired()
                    .HasColumnName("mapType")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PinRadius).HasColumnName("pinRadius");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Settings_Users");
            });

            modelBuilder.Entity<Userss>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnName("created")
                    .IsRowVersion();

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail")
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus)
                    .IsRequired()
                    .HasColumnName("userStatus")
                    .HasMaxLength(19)
                    .IsUnicode(false);
            });
        }
    }
}
