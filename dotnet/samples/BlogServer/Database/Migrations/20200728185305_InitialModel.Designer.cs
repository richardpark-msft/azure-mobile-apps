﻿// <auto-generated />
using System;
using BlogServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogServer.Database.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20200728185305_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogServer.DataObjects.BlogPost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CommentCount")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("PostedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("BlogServer.DataObjects.Bookmark", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmark");
                });

            modelBuilder.Entity("BlogServer.DataObjects.PostComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("PostedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PostId");

                    b.ToTable("PostComments");
                });

            modelBuilder.Entity("BlogServer.DataObjects.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AvatarURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogServer.DataObjects.BlogPost", b =>
                {
                    b.HasOne("BlogServer.DataObjects.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("BlogServer.DataObjects.Bookmark", b =>
                {
                    b.HasOne("BlogServer.DataObjects.BlogPost", null)
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("BlogServer.DataObjects.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BlogServer.DataObjects.PostComment", b =>
                {
                    b.HasOne("BlogServer.DataObjects.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("BlogServer.DataObjects.BlogPost", null)
                        .WithMany()
                        .HasForeignKey("PostId");
                });
#pragma warning restore 612, 618
        }
    }
}
