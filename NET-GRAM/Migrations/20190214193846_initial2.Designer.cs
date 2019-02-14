﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET_GRAM.Data;

namespace NET_GRAM.Migrations
{
    [DbContext(typeof(PostsDbContext))]
    [Migration("20190214193846_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NET_GRAM.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Content");

                    b.Property<int>("PostID");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NET_GRAM.Models.Posts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Capture");

                    b.Property<string>("ImageURL");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Author = "Jimmy",
                            Capture = "Snow day",
                            ImageURL = "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg",
                            Title = "Chace's Pancake Coral"
                        },
                        new
                        {
                            ID = 2,
                            Author = "Bob",
                            Capture = "Snow",
                            ImageURL = "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg",
                            Title = "Chace's Pancake Coral"
                        });
                });

            modelBuilder.Entity("NET_GRAM.Models.Comment", b =>
                {
                    b.HasOne("NET_GRAM.Models.Posts", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
