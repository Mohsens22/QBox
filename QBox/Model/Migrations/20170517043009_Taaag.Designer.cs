using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(Model))]
    [Migration("20170517043009_Taaag")]
    partial class Taaag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Model.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssignedFlag");

                    b.Property<string>("Javab");

                    b.Property<int?>("QuestionID");

                    b.Property<string>("Taaag");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Model.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Model.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Correct");

                    b.Property<int?>("CourseID");

                    b.Property<string>("Soal");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Model.Stat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("All");

                    b.Property<int>("Correct");

                    b.Property<int?>("CourseID");

                    b.Property<DateTime>("Created");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Model.Answer", b =>
                {
                    b.HasOne("Model.Question")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("Model.Question", b =>
                {
                    b.HasOne("Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");
                });

            modelBuilder.Entity("Model.Stat", b =>
                {
                    b.HasOne("Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");
                });
        }
    }
}
