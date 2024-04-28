﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using programming_skills_assessment_backend.Data;

#nullable disable

namespace programming_skills_assessment_backend.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("programming_skills_assessment_backend.Models.AnswerOption", b =>
                {
                    b.Property<Guid>("AnswerOptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OptionNumber")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuestionID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnswerOptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("AnswerOptions");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.Question", b =>
                {
                    b.Property<Guid>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TestID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestionID");

                    b.HasIndex("TestID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.Test", b =>
                {
                    b.Property<Guid>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DurationMinutes")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TestTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TestedSkills")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestID");

                    b.HasIndex("TestTypeID");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.TestType", b =>
                {
                    b.Property<Guid>("TestTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TestTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestTypeID");

                    b.ToTable("TestTypes");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.AnswerOption", b =>
                {
                    b.HasOne("programming_skills_assessment_backend.Models.Question", null)
                        .WithMany("AnswerOptions")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.Question", b =>
                {
                    b.HasOne("programming_skills_assessment_backend.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.Test", b =>
                {
                    b.HasOne("programming_skills_assessment_backend.Models.TestType", "TestType")
                        .WithMany("Tests")
                        .HasForeignKey("TestTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestType");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.Question", b =>
                {
                    b.Navigation("AnswerOptions");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("programming_skills_assessment_backend.Models.TestType", b =>
                {
                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
