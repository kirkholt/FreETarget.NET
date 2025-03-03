﻿// <auto-generated />
using System;
using FreETarget.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreETarget.NET.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Range", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Range", (string)null);
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ResultType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TargetType")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TrackId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Session", (string)null);
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Shot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("A")
                        .HasColumnType("TEXT");

                    b.Property<int>("No")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("R")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ResultDecimal")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ResultInteger")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ResultIntegerX10")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("X")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Y")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK_Shot");

                    b.HasIndex("SessionId");

                    b.ToTable("Shot", (string)null);
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Target", (string)null);
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Track", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("No")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RangeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TargetId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RangeId");

                    b.HasIndex("TargetId")
                        .IsUnique();

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Session", b =>
                {
                    b.HasOne("FreETarget.NET.Data.Entities.Track", "Track")
                        .WithMany("SessionList")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Shot", b =>
                {
                    b.HasOne("FreETarget.NET.Data.Entities.Session", "Session")
                        .WithMany("ShotList")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Track", b =>
                {
                    b.HasOne("FreETarget.NET.Data.Entities.Range", "Range")
                        .WithMany("TrackList")
                        .HasForeignKey("RangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreETarget.NET.Data.Entities.Target", "FreETarget")
                        .WithOne("Track")
                        .HasForeignKey("FreETarget.NET.Data.Entities.Track", "TargetId");

                    b.Navigation("FreETarget");

                    b.Navigation("Range");
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Range", b =>
                {
                    b.Navigation("TrackList");
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Session", b =>
                {
                    b.Navigation("ShotList");
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Target", b =>
                {
                    b.Navigation("Track");
                });

            modelBuilder.Entity("FreETarget.NET.Data.Entities.Track", b =>
                {
                    b.Navigation("SessionList");
                });
#pragma warning restore 612, 618
        }
    }
}
