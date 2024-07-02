﻿// <auto-generated />
using System;
using ECommerce.Ploto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerce.Ploto.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240702094503_seedRoles")]
    partial class seedRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Cart.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.CartItem.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Image");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Image");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Product.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Role.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c75ea36-6235-441f-88f0-8c8ae56ef651"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c82d28b9-7d98-4d43-9270-adedf4d2c945"),
                            Name = "user"
                        });
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AvatarId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Createdby")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId")
                        .IsUnique();

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.ProductImage", b =>
                {
                    b.HasBaseType("ECommerce.Ploto.Domain.Models.Image.Image");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasIndex("ProductId");

                    b.HasDiscriminator().HasValue("ProductImage");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.UserAvaterImage", b =>
                {
                    b.HasBaseType("ECommerce.Ploto.Domain.Models.Image.Image");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasDiscriminator().HasValue("UserAvaterImage");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.CartItem.CartItem", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Cart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Ploto.Domain.Models.Product.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Product.Product", b =>
                {
                    b.OwnsOne("ECommerce.Ploto.Domain.Models.Product.ValueObject.Dimensions", "Dimensions", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<double>("Height")
                                .HasColumnType("double precision")
                                .HasColumnName("dimension_height");

                            b1.Property<double>("Length")
                                .HasColumnType("double precision")
                                .HasColumnName("dimension_length");

                            b1.Property<double>("Width")
                                .HasColumnType("double precision")
                                .HasColumnName("dimension_width");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.Product.ValueObject.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)");

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

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.User.User", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Image.UserAvaterImage", "Avatar")
                        .WithOne("User")
                        .HasForeignKey("ECommerce.Ploto.Domain.Models.User.User", "AvatarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ECommerce.Ploto.Domain.Models.Cart.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("ECommerce.Ploto.Domain.Models.User.User", "CartId");

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.User.ValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Avenue")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("avenue");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)")
                                .HasColumnName("city");

                            b1.Property<int>("HouseNO")
                                .HasColumnType("integer")
                                .HasColumnName("house_no");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.User.ValueObject.HomeNumber", "HomeNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("CityCode")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("character varying(3)")
                                .HasColumnName("city_code");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("home_number");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("ECommerce.Ploto.Domain.Models.User.ValueObject.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirtsName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Avatar");

                    b.Navigation("Cart");

                    b.Navigation("HomeNumber")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Role.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Ploto.Domain.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.ProductImage", b =>
                {
                    b.HasOne("ECommerce.Ploto.Domain.Models.Product.Product", "Product")
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

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Product.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("ECommerce.Ploto.Domain.Models.Image.UserAvaterImage", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
