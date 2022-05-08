﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationalEntityandRotinginWebApi.Data;

namespace RelationalEntityandRotinginWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220407101040_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RelationalEntityandRotinginWebApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("RelationalEntityandRotinginWebApi.Models.EmployeeRegistration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imagepath")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Occupitaion")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("tbl_registeremp");
                });

            modelBuilder.Entity("RelationalEntityandRotinginWebApi.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("post");
                });

            modelBuilder.Entity("RelationalEntityandRotinginWebApi.Models.Post", b =>
                {
                    b.HasOne("RelationalEntityandRotinginWebApi.Models.Category", "Category")
                        .WithMany("Post")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RelationalEntityandRotinginWebApi.Models.Category", b =>
                {
                    b.Navigation("Post");
                });
#pragma warning restore 612, 618
        }
    }
}
