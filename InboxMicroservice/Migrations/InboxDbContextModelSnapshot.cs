﻿// <auto-generated />
using System;
using InboxMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InboxMicroservice.Migrations
{
    [DbContext(typeof(InboxDbContext))]
    partial class InboxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InboxMicroservice.Entities.Inbox", b =>
                {
                    b.Property<int>("InboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InboxId"));

                    b.Property<string>("ActTyp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCtr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InboxId");

                    b.ToTable("Inboxs");
                });

            modelBuilder.Entity("InboxMicroservice.Entities.InboxItem", b =>
                {
                    b.Property<int>("InboxItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InboxItemId"));

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Components")
                        .HasColumnType("int");

                    b.Property<int>("DrawingsAssembly")
                        .HasColumnType("int");

                    b.Property<int>("DrawingsComponents")
                        .HasColumnType("int");

                    b.Property<string>("DueDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ecm")
                        .HasColumnType("int");

                    b.Property<string>("Engineer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Finished")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gpdm")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int?>("InboxId")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Received")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Started")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("System")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhenComplete")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InboxItemId");

                    b.HasIndex("InboxId");

                    b.ToTable("InboxItems");
                });

            modelBuilder.Entity("InboxMicroservice.Entities.InboxItem", b =>
                {
                    b.HasOne("InboxMicroservice.Entities.Inbox", "Inbox")
                        .WithMany("InboxItems")
                        .HasForeignKey("InboxId");

                    b.Navigation("Inbox");
                });

            modelBuilder.Entity("InboxMicroservice.Entities.Inbox", b =>
                {
                    b.Navigation("InboxItems");
                });
#pragma warning restore 612, 618
        }
    }
}
