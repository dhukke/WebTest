﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(TestsDbContext))]
    partial class TestsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplication1.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5093ea56-0453-45d0-b541-fcf3391790a4"),
                            Name = "Court 1"
                        },
                        new
                        {
                            Id = new Guid("e0d9aa06-c626-4fab-9676-b1bad7d0f865"),
                            Name = "Court 2"
                        },
                        new
                        {
                            Id = new Guid("96e15349-d8e7-4b4b-8e89-8ad1440680d3"),
                            Name = "Court 3"
                        },
                        new
                        {
                            Id = new Guid("91bab092-37a9-4673-a7ed-ee3342afe980"),
                            Name = "Court 4"
                        },
                        new
                        {
                            Id = new Guid("342e0a98-37ba-4c0a-b44f-17239045e7c3"),
                            Name = "Court 5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
