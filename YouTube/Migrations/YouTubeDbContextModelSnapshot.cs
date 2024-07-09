﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YouTube.Data;

#nullable disable

namespace YouTube.Migrations
{
    [DbContext(typeof(YouTubeDbContext))]
    partial class YouTubeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YouTube.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nicname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Nicname = "JohnDoe"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1985, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Nicname = "JaneSmith"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1988, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michael.brown@example.com",
                            Name = "Michael Brown",
                            Nicname = "MichaelBrown"
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(1995, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.johnson@example.com",
                            Name = "Emily Johnson",
                            Nicname = "EmilyJohnson"
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(1992, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "william.wilson@example.com",
                            Name = "William Wilson",
                            Nicname = "WilliamWilson"
                        },
                        new
                        {
                            Id = 6,
                            Birthday = new DateTime(1987, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "olivia.davis@example.com",
                            Name = "Olivia Davis",
                            Nicname = "OliviaDavis"
                        },
                        new
                        {
                            Id = 7,
                            Birthday = new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "james.miller@example.com",
                            Name = "James Miller",
                            Nicname = "JamesMiller"
                        },
                        new
                        {
                            Id = 8,
                            Birthday = new DateTime(1983, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sophia.martinez@example.com",
                            Name = "Sophia Martinez",
                            Nicname = "SophiaMartinez"
                        },
                        new
                        {
                            Id = 9,
                            Birthday = new DateTime(1991, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "benjamin.garcia@example.com",
                            Name = "Benjamin Garcia",
                            Nicname = "BenjaminGarcia"
                        },
                        new
                        {
                            Id = 10,
                            Birthday = new DateTime(1989, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "isabella.lopez@example.com",
                            Name = "Isabella Lopez",
                            Nicname = "IsabellaLopez"
                        });
                });

            modelBuilder.Entity("YouTube.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A beginner's guide to C#.",
                            Title = "Introduction to C#",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Deep dive into Java programming.",
                            Title = "Advanced Java Programming",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Everything you need to know about JavaScript.",
                            Title = "JavaScript Essentials",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Using Python for data analysis and machine learning.",
                            Title = "Python for Data Science",
                            UserId = 5
                        },
                        new
                        {
                            Id = 5,
                            Description = "Building modern web applications with React.",
                            Title = "Web Development with React",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Learn how to manage databases using SQL.",
                            Title = "Database Management with SQL",
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            Description = "An introduction to cybersecurity principles.",
                            Title = "Cybersecurity Basics",
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            Description = "Creating mobile applications for Android and iOS.",
                            Title = "Mobile App Development",
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            Description = "Understanding cloud computing with AWS.",
                            Title = "Cloud Computing with AWS",
                            UserId = 5
                        },
                        new
                        {
                            Id = 10,
                            Description = "Exploring AI and machine learning concepts.",
                            Title = "Artificial Intelligence and Machine Learning",
                            UserId = 10
                        });
                });

            modelBuilder.Entity("YouTube.Entities.Video", b =>
                {
                    b.HasOne("YouTube.Entities.User", "User")
                        .WithMany("Videos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("YouTube.Entities.User", b =>
                {
                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
