using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MWeb_test1.Models
{
    public partial class Mweb1Context : DbContext
    {
        public Mweb1Context()
        {
        }

        public Mweb1Context(DbContextOptions<Mweb1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Marker> Marker { get; set; }
        public virtual DbSet<UserSetting> UserSetting { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=Mweb1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.MarkerId)
                    .HasName("IX_Comments_markerID");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Comments_userID");

                entity.Property(e => e.CommentId).HasColumnName("commentID");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.MarkerId).HasColumnName("markerID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Marker)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.MarkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Marker");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Marker>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Markers_userID");

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
                    .WithMany(p => p.Marker)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marker_User");
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK_Setting");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserSettings_userID");

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
                    .WithMany(p => p.UserSetting)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Settings_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

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
