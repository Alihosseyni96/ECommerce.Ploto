﻿// <auto-generated />
using System;
using ECommerce.Ploto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Ploto.Infrastructure.Migrations
{
    [DbContext(typeof(PlotoDbContext))]
    [Migration("20240907135648_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Cart.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Image");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Image");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2bd003ba-7ac6-4885-a0a7-847540d21487"),
                            PermissionType = 1
                        },
                        new
                        {
                            Id = new Guid("58101b53-d503-4c7b-8b99-76b82866ce41"),
                            PermissionType = 0
                        });
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe6c2668-f747-453c-8895-b1adedf21739"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("56f1af2c-41a2-43f2-84d8-53a2d688ddb6"),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.RolePermissionModel.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("63fd1c45-27e8-4354-ad7e-eb9245c16d91"),
                            PermissionId = new Guid("2bd003ba-7ac6-4885-a0a7-847540d21487"),
                            RoleId = new Guid("fe6c2668-f747-453c-8895-b1adedf21739")
                        },
                        new
                        {
                            Id = new Guid("8397ba17-bf53-4762-b3b9-07742171d1ef"),
                            PermissionId = new Guid("58101b53-d503-4c7b-8b99-76b82866ce41"),
                            RoleId = new Guid("fe6c2668-f747-453c-8895-b1adedf21739")
                        },
                        new
                        {
                            Id = new Guid("43ca071c-fc9b-4967-940b-7fb1ca3e0b09"),
                            PermissionId = new Guid("2bd003ba-7ac6-4885-a0a7-847540d21487"),
                            RoleId = new Guid("56f1af2c-41a2-43f2-84d8-53a2d688ddb6")
                        });
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AvatarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId")
                        .IsUnique()
                        .HasFilter("[AvatarId] IS NOT NULL");

                    b.HasIndex("CartId")
                        .IsUnique()
                        .HasFilter("[CartId] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce0739ae-de1c-48ca-9670-3ab874c1ea54"),
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            PhoneNumber = "09386562888",
                            RoleId = new Guid("fe6c2668-f747-453c-8895-b1adedf21739")
                        });
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.ProductImage", b =>
                {
                    b.HasBaseType("ECommerce.Ploto.Domain.Models.Image.Image");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductId");

                    b.HasDiscriminator().HasValue("ProductImage");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.UserAvaterImage", b =>
                {
                    b.HasBaseType("ECommerce.Ploto.Domain.Models.Image.Image");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue("UserAvaterImage");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.CartItem", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Cart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Ploto.Domain.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Product", b =>
                {
                    b.OwnsOne("ECommerce.Ploto.Domain.Models.Dimensions", "Dimensions", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Height")
                                .HasColumnType("float")
                                .HasColumnName("dimension_height");

                            b1.Property<double>("Length")
                                .HasColumnType("float")
                                .HasColumnName("dimension_length");

                            b1.Property<double>("Width")
                                .HasColumnType("float")
                                .HasColumnName("dimension_width");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Dimensions")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.RolePermissionModel.RolePermission", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce.Ploto.Domain.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.User", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Image.UserAvaterImage", "Avatar")
                        .WithOne("User")
                        .HasForeignKey("ECommerce.Ploto.Domain.Models.User", "AvatarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Ploto.Domain.Models.Cart.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("ECommerce.Ploto.Domain.Models.User", "CartId");

                    b.HasOne("ECommerce.Ploto.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce.Ploto.Domain.Models.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId1");

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Avenue")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<int>("HouseNO")
                                .HasColumnType("int");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("ce0739ae-de1c-48ca-9670-3ab874c1ea54"),
                                    Avenue = "resalat",
                                    City = "tehran",
                                    HouseNO = 54
                                });
                        });

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.HomeNumber", "HomeNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CityCode")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("ce0739ae-de1c-48ca-9670-3ab874c1ea54"),
                                    CityCode = "021",
                                    Number = "123456799"
                                });
                        });

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirtsName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("ce0739ae-de1c-48ca-9670-3ab874c1ea54"),
                                    FirtsName = "pourya",
                                    LastName = "hosseyni"
                                });
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Avatar");

                    b.Navigation("Cart");

                    b.Navigation("HomeNumber")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.ProductImage", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Cart.Cart", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.UserAvaterImage", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}