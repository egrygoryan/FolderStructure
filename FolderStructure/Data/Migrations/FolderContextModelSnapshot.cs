﻿// <auto-generated />
using System;
using FolderStructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FolderStructure.Data.Migrations
{
    [DbContext(typeof(FolderContext))]
    partial class FolderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("FolderStructure.Domain.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FolderName = "Creating Digital Images"
                        },
                        new
                        {
                            Id = 2,
                            FolderName = "Resources",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 3,
                            FolderName = "Evidence",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 4,
                            FolderName = "Graphic Products",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            FolderName = "Primary Sources",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 6,
                            FolderName = "Secondary Sources",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 7,
                            FolderName = "Process",
                            ParentId = 4
                        },
                        new
                        {
                            Id = 8,
                            FolderName = "Final Product",
                            ParentId = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
