﻿// <auto-generated />
using System;
using FabricMarket_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FabricMarket_DAL.Migrations
{
    [DbContext(typeof(FabricMarketDbContext))]
    [Migration("20240207163735_AddSystemSettings")]
    partial class AddSystemSettings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FabricType");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricVariant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FabricTypeId")
                        .HasColumnType("bigint");

                    b.Property<double>("MassPerSquareMeter")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Thickness")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FabricTypeId");

                    b.ToTable("FabricVariant");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.Vendor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.VendorProvidesFabric", b =>
                {
                    b.Property<long>("VendorId")
                        .HasColumnType("bigint");

                    b.Property<long>("FabricVariantId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasColumnType("numeric");

                    b.HasKey("VendorId", "FabricVariantId");

                    b.HasIndex("FabricVariantId");

                    b.ToTable("VendorProvidesFabric");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.Identity.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.Identity.UserSettings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("DarkThemeEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.SystemSettings.SystemSettings", b =>
                {
                    b.Property<int>("SettingId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SettingId");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricVariant", b =>
                {
                    b.HasOne("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricType", "FabricType")
                        .WithMany("Variants")
                        .HasForeignKey("FabricTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FabricType");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.VendorProvidesFabric", b =>
                {
                    b.HasOne("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricVariant", "FabricVariant")
                        .WithMany("Sources")
                        .HasForeignKey("FabricVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lesson11_FabricMarket_DomainModel.Models.FabricProduction.Vendor", "Vendor")
                        .WithMany("Provides")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FabricVariant");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.Identity.User", b =>
                {
                    b.HasOne("lesson11_FabricMarket_DomainModel.Models.Identity.UserSettings", "UserSettings")
                        .WithOne()
                        .HasForeignKey("lesson11_FabricMarket_DomainModel.Models.Identity.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserSettings");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.Identity.UserSettings", b =>
                {
                    b.HasOne("lesson11_FabricMarket_DomainModel.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricType", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.FabricVariant", b =>
                {
                    b.Navigation("Sources");
                });

            modelBuilder.Entity("lesson11_FabricMarket_DomainModel.Models.FabricProduction.Vendor", b =>
                {
                    b.Navigation("Provides");
                });
#pragma warning restore 612, 618
        }
    }
}
