using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Model.Answers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("AssignedFlag");

                    b.Property<int?>("QuestionsID");

                    b.HasKey("ID");

                    b.HasIndex("QuestionsID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Model.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Model.Questions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Correct");

                    b.Property<int?>("CourseID");

                    b.Property<string>("Question");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Model.Stats", b =>
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

            modelBuilder.Entity("Model.Answers", b =>
                {
                    b.HasOne("Model.Questions")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionsID");
                });

            modelBuilder.Entity("Model.Questions", b =>
                {
                    b.HasOne("Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");
                });

            modelBuilder.Entity("Model.Stats", b =>
                {
                    b.HasOne("Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");
                });
        }
    }
}
