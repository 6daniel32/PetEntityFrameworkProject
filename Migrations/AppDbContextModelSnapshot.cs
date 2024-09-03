﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetEntityFrameworkProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("AddressId");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseTrainee", b =>
                {
                    b.Property<Guid>("CoursesCourseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TraineesTraineeId")
                        .HasColumnType("uuid");

                    b.HasKey("CoursesCourseId", "TraineesTraineeId");

                    b.HasIndex("TraineesTraineeId");

                    b.ToTable("CourseTrainee");
                });

            modelBuilder.Entity("Test", b =>
                {
                    b.Property<Guid>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TestTrainee", b =>
                {
                    b.Property<Guid>("TestsTestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TraineesTraineeId")
                        .HasColumnType("uuid");

                    b.HasKey("TestsTestId", "TraineesTraineeId");

                    b.HasIndex("TraineesTraineeId");

                    b.ToTable("TestTrainee");
                });

            modelBuilder.Entity("Trainee", b =>
                {
                    b.Property<Guid>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("TraineeId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Address", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithOne("Address")
                        .HasForeignKey("Address", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CourseTrainee", b =>
                {
                    b.HasOne("Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trainee", null)
                        .WithMany()
                        .HasForeignKey("TraineesTraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestTrainee", b =>
                {
                    b.HasOne("Test", null)
                        .WithMany()
                        .HasForeignKey("TestsTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trainee", null)
                        .WithMany()
                        .HasForeignKey("TraineesTraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trainee", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany("Trainees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Company", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
