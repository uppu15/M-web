﻿// <auto-generated />
using System;
using MWeb1_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MWeb1_2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190930182554_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MWeb1_2.Models.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("comments");

                    b.Property<string>("markerID");

                    b.Property<int>("userID");

                    b.HasKey("commentID");

                    b.HasIndex("markerID");

                    b.HasIndex("userID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MWeb1_2.Models.Marker", b =>
                {
                    b.Property<string>("markerID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("markerLat");

                    b.Property<double>("markerLng");

                    b.Property<byte[]>("photo");

                    b.Property<string>("photoPath");

                    b.Property<int>("userID");

                    b.HasKey("markerID");

                    b.HasIndex("userID");

                    b.ToTable("Markers");
                });

            modelBuilder.Entity("MWeb1_2.Models.UserSetting", b =>
                {
                    b.Property<int>("settingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Gps");

                    b.Property<decimal>("centerLat");

                    b.Property<decimal>("centerLng");

                    b.Property<int>("centerZoom");

                    b.Property<string>("mapType");

                    b.Property<int>("pinRadius");

                    b.Property<int>("userID");

                    b.HasKey("settingID");

                    b.HasIndex("userID");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("MWeb1_2.Models.Users", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("created");

                    b.Property<string>("userEmail");

                    b.Property<string>("userName");

                    b.Property<string>("userPassword");

                    b.Property<string>("userStatus");

                    b.HasKey("userID");

                    b.ToTable("Userss");
                });

            modelBuilder.Entity("MWeb1_2.Models.Comment", b =>
                {
                    b.HasOne("MWeb1_2.Models.Marker", "Marker")
                        .WithMany("Comments")
                        .HasForeignKey("markerID");

                    b.HasOne("MWeb1_2.Models.Users", "Userss")
                        .WithMany("Comments")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MWeb1_2.Models.Marker", b =>
                {
                    b.HasOne("MWeb1_2.Models.Users", "Userss")
                        .WithMany("Markers")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MWeb1_2.Models.UserSetting", b =>
                {
                    b.HasOne("MWeb1_2.Models.Users", "Userss")
                        .WithMany("UserSettings")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
