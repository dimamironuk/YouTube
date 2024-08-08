﻿// <auto-generated />
using System;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(YouTubeDbContext))]
    [Migration("20240805071809_UpdateAvatarUser")]
    partial class UpdateAvatarUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.User", b =>
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

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarUrl = "https://www.cnet.com/a/img/resize/20d6844768bd3f5f0df41deee97897423bcaf3c5/hub/2021/11/03/3c2a7d79-770e-4cfa-9847-66b3901fb5d7/c09.jpg?auto=webp&fit=crop&height=1200&width=1200",
                            Birthday = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Nickname = "JohnDoe",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 2,
                            AvatarUrl = "https://i.pinimg.com/236x/6f/0c/7d/6f0c7dd236a49fef3d2c7ad9def7f87c.jpg",
                            Birthday = new DateTime(1985, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Nickname = "JaneSmith",
                            Password = "qwerty"
                        },
                        new
                        {
                            Id = 3,
                            AvatarUrl = "https://i.pinimg.com/236x/ef/31/da/ef31da3aac21d75fede9d3ca00b8f14f.jpg",
                            Birthday = new DateTime(1988, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michael.brown@example.com",
                            Name = "Michael Brown",
                            Nickname = "MichaelBrown",
                            Password = "221002"
                        },
                        new
                        {
                            Id = 4,
                            AvatarUrl = "https://i.pinimg.com/236x/5b/02/47/5b0247d140ff9659066d61fa63edc79a.jpg",
                            Birthday = new DateTime(1995, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.johnson@example.com",
                            Name = "Emily Johnson",
                            Nickname = "EmilyJohnson",
                            Password = "school1"
                        },
                        new
                        {
                            Id = 5,
                            AvatarUrl = "https://i.pinimg.com/236x/28/6d/91/286d914fd4f3739e4b063aaf7875a04a.jpg",
                            Birthday = new DateTime(1992, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "william.wilson@example.com",
                            Name = "William Wilson",
                            Nickname = "WilliamWilson",
                            Password = "412512"
                        },
                        new
                        {
                            Id = 6,
                            AvatarUrl = "https://i.pinimg.com/236x/b1/d8/db/b1d8dbf9167c52e0615adc13437f07bf.jpg",
                            Birthday = new DateTime(1987, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "olivia.davis@example.com",
                            Name = "Olivia Davis",
                            Nickname = "OliviaDavis",
                            Password = "satq24"
                        },
                        new
                        {
                            Id = 7,
                            AvatarUrl = "https://i.pinimg.com/236x/f8/32/e9/f832e9eeb044c0724ed38d11a6fc3c52.jpg",
                            Birthday = new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "james.miller@example.com",
                            Name = "James Miller",
                            Nickname = "JamesMiller",
                            Password = "rq24ar"
                        },
                        new
                        {
                            Id = 8,
                            AvatarUrl = "https://i.pinimg.com/236x/74/a2/9b/74a29b1557ea388218519536143e3eee.jpg",
                            Birthday = new DateTime(1983, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sophia.martinez@example.com",
                            Name = "Sophia Martinez",
                            Nickname = "SophiaMartinez",
                            Password = "52356"
                        },
                        new
                        {
                            Id = 9,
                            AvatarUrl = "https://cdn-0001.qstv.on.epicgames.com/spbduGeODldQXSaWaZ/image/landscape_comp.jpeg",
                            Birthday = new DateTime(1991, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "benjamin.garcia@example.com",
                            Name = "Benjamin Garcia",
                            Nickname = "BenjaminGarcia",
                            Password = "rEe24"
                        },
                        new
                        {
                            Id = 10,
                            AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/9/96/Meme_Man_on_transparent_background.webp/316px-Meme_Man_on_transparent_background.webp.png",
                            Birthday = new DateTime(1989, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "isabella.lopez@example.com",
                            Name = "Isabella Lopez",
                            Nickname = "IsabellaLopez",
                            Password = "rw0wrq"
                        });
                });

            modelBuilder.Entity("Data.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfPublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviewUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfPublication = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A beginner's guide to C#",
                            PreviewUrl = "https://static-cse.canva.com/blob/1633154/1600w-wK95f3XNRaM.53b81e59.jpg",
                            Title = "Introduction to C#",
                            UserId = 1,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 2,
                            DateOfPublication = new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Deep dive into Java programming.",
                            PreviewUrl = "https://marketplace.canva.com/EAFf5rfnPgA/1/0/1600w/canva-blue-modern-eye-catching-vlog-youtube-thumbnail-LEcp-BYepDU.jpg",
                            Title = "Advanced Java Programming",
                            UserId = 2,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 3,
                            DateOfPublication = new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Everything you need to know about JavaScript.",
                            PreviewUrl = "https://i0.wp.com/i.pinimg.com/originals/d4/94/76/d49476e6169ae02dd0eea882b1443586.jpg?resize=160,120",
                            Title = "JavaScript Essentials",
                            UserId = 2,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 4,
                            DateOfPublication = new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Using Python for data analysis and machine learning.",
                            PreviewUrl = "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/125342479/original/7b112c248eb522d29016e1cca95a7ccd9cf50d6f/design-eye-catchy-youtube-thumbnail-in-2-hours.jpg",
                            Title = "Python for Data Science",
                            UserId = 5,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 5,
                            DateOfPublication = new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Building modern web applications with React.",
                            PreviewUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB-bmx9MFjFvH0p1MZzMU8fwYPAO-mzUhZM6di1tsXrzWfSdXyvJyr1Ry503HmyDnt8ns&usqp=CAU",
                            Title = "Web Development with React",
                            UserId = 1,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 6,
                            DateOfPublication = new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Learn how to manage databases using SQL.",
                            PreviewUrl = "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/163993931/original/bea1055dbfd13392ad4d291eae22fb9cd3a84484/design-amazing-youtube-thumbnail-in-3-hours.jpg",
                            Title = "Database Management with SQL",
                            UserId = 6,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 7,
                            DateOfPublication = new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "An introduction to cybersecurity principles.",
                            PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/pbdwbva4-WI/maxresdefault.jpg?resize=160,120",
                            Title = "Cybersecurity Basics",
                            UserId = 7,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 8,
                            DateOfPublication = new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Creating mobile applications for Android and iOS.",
                            PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/eftWmNzWbxk/maxresdefault.jpg?resize=160,120",
                            Title = "Mobile App Development",
                            UserId = 8,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 9,
                            DateOfPublication = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Understanding cloud computing with AWS.",
                            PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/8YbZuaBP9B8/maxresdefault.jpg?resize=160,120",
                            Title = "Cloud Computing with AWS",
                            UserId = 5,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        },
                        new
                        {
                            Id = 10,
                            DateOfPublication = new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Exploring AI and machine learning concepts.",
                            PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/CJ3hfxxlF2Q/maxresdefault.jpg?resize=160,120",
                            Title = "Artificial Intelligence and Machine Learning",
                            UserId = 10,
                            VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us"
                        });
                });

            modelBuilder.Entity("Data.Entities.Video", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Videos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}