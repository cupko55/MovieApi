﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Seminar.DAL;
using System;

namespace Seminar.DAL.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20180124175255_annotations")]
    partial class annotations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Seminar.Model.LeadingActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 665, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("LeadingActor");
                });

            modelBuilder.Entity("Seminar.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 661, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 665, DateTimeKind.Local));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("NominationsCount");

                    b.Property<int>("NominationsWin");

                    b.Property<decimal>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Seminar.Model.MovieLeadingActor", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("LeadingActorId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 706, DateTimeKind.Local));

                    b.HasKey("MovieId", "LeadingActorId");

                    b.HasIndex("LeadingActorId");

                    b.ToTable("MovieLeadingActor");
                });

            modelBuilder.Entity("Seminar.Model.MovieType", b =>
                {
                    b.Property<int>("TypeId");

                    b.Property<int>("MovieId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

                    b.HasKey("TypeId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieType");
                });

            modelBuilder.Entity("Seminar.Model.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("Seminar.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Seminar.Model.MovieLeadingActor", b =>
                {
                    b.HasOne("Seminar.Model.LeadingActor", "LeadingActor")
                        .WithMany("MovieLeadingActors")
                        .HasForeignKey("LeadingActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Seminar.Model.Movie", "Movie")
                        .WithMany("MovieLeadingActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Seminar.Model.MovieType", b =>
                {
                    b.HasOne("Seminar.Model.Movie", "Movie")
                        .WithMany("MovieTypes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Seminar.Model.Type", "Type")
                        .WithMany("MovieTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}