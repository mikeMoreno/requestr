﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Requestr.DAL;

#nullable disable

namespace Requestr.DAL.Migrations
{
    [DbContext(typeof(RequestrDbContext))]
    partial class RequestrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Requestr.DAL.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CollectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Requestr.DAL.Models.RequestCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestCollections");
                });

            modelBuilder.Entity("Requestr.DAL.Models.Request", b =>
                {
                    b.HasOne("Requestr.DAL.Models.RequestCollection", "Collection")
                        .WithMany("Requests")
                        .HasForeignKey("CollectionId");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Requestr.DAL.Models.RequestCollection", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
