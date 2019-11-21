﻿// <auto-generated />
using System;
using MWeb_test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MWeb_test.Migrations
{
    [DbContext(typeof(Mweb_DataTableFirstContext))]
    [Migration("20191028172207_AddingIdentity")]
    partial class AddingIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MWeb_test.Models.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("commentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnName("comment");

                    b.Property<int>("MarkerId")
                        .HasColumnName("markerID");

                    b.Property<int>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("CommentId")
                        .HasName("PK_Comment");

                    b.HasIndex("MarkerId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MWeb_test.Models.Markers", b =>
                {
                    b.Property<int>("MarkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("markerID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("MarkerLat")
                        .HasColumnName("markerLat")
                        .HasColumnType("decimal(10, 6)");

                    b.Property<decimal>("MarkerLng")
                        .HasColumnName("markerLng")
                        .HasColumnType("decimal(10, 6)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnName("photo")
                        .HasColumnType("image");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnName("photoPath")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("MarkerId")
                        .HasName("PK_Marker");

                    b.HasIndex("UserId");

                    b.ToTable("Markers");
                });

            modelBuilder.Entity("MWeb_test.Models.UserSettings", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("settingID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CenterLat")
                        .HasColumnName("centerLat")
                        .HasColumnType("decimal(10, 6)");

                    b.Property<decimal>("CenterLng")
                        .HasColumnName("centerLng")
                        .HasColumnType("decimal(10, 6)");

                    b.Property<int>("CenterZoom")
                        .HasColumnName("centerZoom");

                    b.Property<bool>("Gps")
                        .HasColumnName("GPS");

                    b.Property<string>("MapType")
                        .IsRequired()
                        .HasColumnName("mapType")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<int>("PinRadius")
                        .HasColumnName("pinRadius");

                    b.Property<int>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("SettingId")
                        .HasName("PK_Setting");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("MWeb_test.Models.Userss", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Created")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("created");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnName("userEmail")
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("userName")
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnName("userPassword")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnName("userStatus")
                        .HasMaxLength(19)
                        .IsUnicode(false);

                    b.HasKey("UserId")
                        .HasName("PK_Users");

                    b.ToTable("Userss");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MWeb_test.Models.Comments", b =>
                {
                    b.HasOne("MWeb_test.Models.Markers", "Marker")
                        .WithMany("Comments")
                        .HasForeignKey("MarkerId")
                        .HasConstraintName("FK_Comment_Marker");

                    b.HasOne("MWeb_test.Models.Userss", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Comment_User");
                });

            modelBuilder.Entity("MWeb_test.Models.Markers", b =>
                {
                    b.HasOne("MWeb_test.Models.Userss", "User")
                        .WithMany("Markers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Marker_User");
                });

            modelBuilder.Entity("MWeb_test.Models.UserSettings", b =>
                {
                    b.HasOne("MWeb_test.Models.Userss", "User")
                        .WithMany("UserSettings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Settings_Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}