﻿// <auto-generated />
using System;
using Blog.Entity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.WebUI.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20191107232248_ImageAddUserPath")]
    partial class ImageAddUserPath
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Entity.Data.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Contet");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Head");

                    b.Property<int>("ImageId");

                    b.Property<int>("Like");

                    b.Property<string>("UserId");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Blog.Entity.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Blog.Entity.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId");

                    b.Property<string>("Context");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Blog.Entity.Data.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BPath")
                        .HasMaxLength(256);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("MPath")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("SPath")
                        .HasMaxLength(256);

                    b.Property<string>("SliderPath")
                        .HasMaxLength(256);

                    b.Property<string>("UserPath")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Blog.Entity.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("ImageId");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blog.Entity.Data.Article", b =>
                {
                    b.HasOne("Blog.Entity.Data.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.Entity.Data.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.Entity.Data.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Blog.Entity.Data.Comment", b =>
                {
                    b.HasOne("Blog.Entity.Data.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.Entity.Data.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Blog.Entity.Data.User", b =>
                {
                    b.HasOne("Blog.Entity.Data.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId");
                });
#pragma warning restore 612, 618
        }
    }
}
