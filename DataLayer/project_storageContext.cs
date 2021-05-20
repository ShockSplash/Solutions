using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjectStore
{
    public partial class project_storageContext : DbContext
    {
        public project_storageContext()
        {
        }

        public project_storageContext(DbContextOptions<project_storageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Solution> Solutions { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=project_storage;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "solution_status", new[] { "NotStarted", "Active", "Completed" })
                .HasPostgresEnum(null, "task_status", new[] { "ToDo", "InProgress", "Done" })
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251@icu");

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.ToTable("solutions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("date")
                    .HasColumnName("completion_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.solution_status)
                .HasColumnType("solution_status")
                .HasColumnName("current_status");

                entity.Property(e => e.solution_status)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (SolutionsStatus)Enum.Parse(typeof(SolutionsStatus), v))
                .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.SolutionId).HasColumnName("solution_id");

                entity.Property(e => e.TaskName).HasColumnName("task_name");

                entity.HasOne(d => d.Solution)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.SolutionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tasks_solution_id_fkey");

                entity.Property(e => e.task_status)
                .HasColumnType("task_status")
                .HasColumnName("current_task_status");

                entity.Property(e => e.task_status)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (TasksStatus)Enum.Parse(typeof(TasksStatus), v))
                .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
