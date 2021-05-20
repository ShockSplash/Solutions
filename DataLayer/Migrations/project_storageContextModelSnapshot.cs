﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectStore;

namespace DataLayer.Migrations
{
    [DbContext(typeof(project_storageContext))]
    partial class project_storageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresEnum(null, "solution_status", new[] { "NotStarted", "Active", "Completed" })
                .HasPostgresEnum(null, "task_status", new[] { "ToDo", "InProgress", "Done" })
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251@icu")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProjectStore.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("date")
                        .HasColumnName("completion_date");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.ToTable("solutions");
                });

            modelBuilder.Entity("ProjectStore.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<int?>("SolutionId")
                        .HasColumnType("integer")
                        .HasColumnName("solution_id");

                    b.Property<string>("TaskName")
                        .HasColumnType("text")
                        .HasColumnName("task_name");

                    b.HasKey("Id");

                    b.HasIndex("SolutionId");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("ProjectStore.Task", b =>
                {
                    b.HasOne("ProjectStore.Solution", "Solution")
                        .WithMany("Tasks")
                        .HasForeignKey("SolutionId")
                        .HasConstraintName("tasks_solution_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("ProjectStore.Solution", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
