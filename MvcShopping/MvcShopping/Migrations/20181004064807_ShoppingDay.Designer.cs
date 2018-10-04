﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcShopping.Models;

namespace MvcShopping.Migrations
{
    [DbContext(typeof(MvcShoppingContext))]
    [Migration("20181004064807_ShoppingDay")]
    partial class ShoppingDay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcShopping.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<short>("Number");

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MvcShopping.Models.ShoppingDay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ShoppingDate");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ID");

                    b.ToTable("ShoppingDay");
                });
#pragma warning restore 612, 618
        }
    }
}