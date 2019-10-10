﻿// <auto-generated />
using System;
using Bazzar.Infrastructures.Data.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bazzar.Infrastructures.Data.SqlServer.Migrations
{
    [DbContext(typeof(AdvertismentDbContext))]
    [Migration("20191010212702_add-version-to-root")]
    partial class addversiontoroot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bazzar.Core.Domain.Advertisements.Entities.Advertisment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Version")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Advertisments");
                });

            modelBuilder.Entity("Bazzar.Core.Domain.Advertisements.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdvertismentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertismentId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("Bazzar.Core.Domain.UserProfiles.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Version")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Bazzar.Core.Domain.Advertisements.Entities.Picture", b =>
                {
                    b.HasOne("Bazzar.Core.Domain.Advertisements.Entities.Advertisment", null)
                        .WithMany("Pictures")
                        .HasForeignKey("AdvertismentId");

                    b.OwnsOne("Bazzar.Core.Domain.Advertisements.ValueObjects.PictureSize", "Size", b1 =>
                        {
                            b1.Property<Guid>("PictureId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Height")
                                .HasColumnType("int");

                            b1.Property<int>("Width")
                                .HasColumnType("int");

                            b1.HasKey("PictureId");

                            b1.ToTable("Picture");

                            b1.WithOwner()
                                .HasForeignKey("PictureId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
