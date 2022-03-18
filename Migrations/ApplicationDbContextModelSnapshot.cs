﻿// <auto-generated />
using System;
using FaceRecognitionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FaceRecognitionApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("FaceRecognitionApp.Models.AttendanceEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AttendanceDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LectureID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LectureID");

                    b.HasIndex("StudentID");

                    b.ToTable("AttendanceEntries");
                });

            modelBuilder.Entity("FaceRecognitionApp.Models.Lecture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LectureDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("LecturerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("FaceRecognitionApp.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LectureID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("LectureID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FaceRecognitionApp.Models.AttendanceEntry", b =>
                {
                    b.HasOne("FaceRecognitionApp.Models.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureID");

                    b.HasOne("FaceRecognitionApp.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Lecture");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FaceRecognitionApp.Models.Student", b =>
                {
                    b.HasOne("FaceRecognitionApp.Models.Lecture", "Lecture")
                        .WithMany("Students")
                        .HasForeignKey("LectureID");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("FaceRecognitionApp.Models.Lecture", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
