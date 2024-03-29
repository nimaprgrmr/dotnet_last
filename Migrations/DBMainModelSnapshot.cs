﻿// <auto-generated />
using System;
using Eshop2.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace Eshop2.Migrations
{
    [DbContext(typeof(DBMain))]
    partial class DBMainModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Eshop2.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Point>("Location")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("geography")
                        .HasDefaultValue((NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (0 0)"));

                    b.Property<string>("NameFamily")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<int>("PostCode")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasAlternateKey("Username");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Eshop2.Models.Buy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Buy", (string)null);
                });

            modelBuilder.Entity("Eshop2.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ProductID");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Eshop2.Models.DetailsBuy", b =>
                {
                    b.Property<int>("BuyID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("TPrice")
                        .HasColumnType("int");

                    b.HasKey("BuyID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("DetailsBuy", (string)null);
                });

            modelBuilder.Entity("Eshop2.Models.Others", b =>
                {
                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CodeNation")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.HasKey("AccountID");

                    b.HasAlternateKey("CodeNation");

                    b.ToTable("Others", (string)null);
                });

            modelBuilder.Entity("Eshop2.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Count")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<int>("FPrice")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Types")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Eshop2.Models.Buy", b =>
                {
                    b.HasOne("Eshop2.Models.Account", "account")
                        .WithMany("buys")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("Eshop2.Models.Comment", b =>
                {
                    b.HasOne("Eshop2.Models.Account", "account")
                        .WithMany("comments")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eshop2.Models.Product", "product")
                        .WithMany("comments")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Eshop2.Models.DetailsBuy", b =>
                {
                    b.HasOne("Eshop2.Models.Buy", "buy")
                        .WithMany("detailsbuy")
                        .HasForeignKey("BuyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eshop2.Models.Product", "product")
                        .WithMany("detailsbuy")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("buy");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Eshop2.Models.Others", b =>
                {
                    b.HasOne("Eshop2.Models.Account", "account")
                        .WithOne("other")
                        .HasForeignKey("Eshop2.Models.Others", "AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("Eshop2.Models.Account", b =>
                {
                    b.Navigation("buys");

                    b.Navigation("comments");

                    b.Navigation("other")
                        .IsRequired();
                });

            modelBuilder.Entity("Eshop2.Models.Buy", b =>
                {
                    b.Navigation("detailsbuy");
                });

            modelBuilder.Entity("Eshop2.Models.Product", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("detailsbuy");
                });
#pragma warning restore 612, 618
        }
    }
}
