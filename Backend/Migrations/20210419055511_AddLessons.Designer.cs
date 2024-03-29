﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolRegister.Database;

namespace SchoolRegister.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210419055511_AddLessons")]
    partial class AddLessons
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GroupStudent", b =>
                {
                    b.Property<string>("GroupsName")
                        .HasColumnType("text");

                    b.Property<int>("StudentsId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsName", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("GroupStudent");
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.Property<int>("ChildrenId")
                        .HasColumnType("integer");

                    b.Property<int>("ParentsId")
                        .HasColumnType("integer");

                    b.HasKey("ChildrenId", "ParentsId");

                    b.HasIndex("ParentsId");

                    b.ToTable("ParentStudent");
                });

            modelBuilder.Entity("SchoolRegister.Models.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("IsWholeClass")
                        .HasColumnType("boolean");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SchoolRegister.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<string>("Topic")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GroupName");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SchoolRegister.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("SchoolRegister.Models.Parent", b =>
                {
                    b.HasBaseType("SchoolRegister.Models.User");

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("SchoolRegister.Models.Student", b =>
                {
                    b.HasBaseType("SchoolRegister.Models.User");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("SchoolRegister.Models.Teacher", b =>
                {
                    b.HasBaseType("SchoolRegister.Models.User");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("GroupStudent", b =>
                {
                    b.HasOne("SchoolRegister.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolRegister.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.HasOne("SchoolRegister.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("ChildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolRegister.Models.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolRegister.Models.Group", b =>
                {
                    b.HasOne("SchoolRegister.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolRegister.Models.Lesson", b =>
                {
                    b.HasOne("SchoolRegister.Models.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupName");

                    b.HasOne("SchoolRegister.Models.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolRegister.Models.Group", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("SchoolRegister.Models.Teacher", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
