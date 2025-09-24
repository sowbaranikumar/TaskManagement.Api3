
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entity.Entities;

namespace TaskManagement.Data.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Project> Projects => Set<Project>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

     
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Role = "Manager" },
                new User { Id = 2, Name = "Bob Smith", Email = "bob@example.com", Role = "Developer" },
                new User { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com", Role = "Tester" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Project Alpha" },
                new Project { Id = 2, Name = "Project Beta" }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Design DB Schema", Description = "Create ER diagram", DueDate = new DateTime(2025, 09, 20), Priority = 1, IsCompleted = false, UserId = 1, ProjectId = 1 },
                new TaskItem { Id = 2, Title = "Setup API Project", Description = "Initialize Web API", DueDate = new DateTime(2025, 09, 22), Priority = 2, IsCompleted = false, UserId = 2, ProjectId = 1 },
                new TaskItem { Id = 3, Title = "Implement Authentication", Description = "Add JWT support", DueDate = new DateTime(2025, 09, 25), Priority = 3, IsCompleted = false, UserId = 2, ProjectId = 1 },
                new TaskItem { Id = 4, Title = "Write Unit Tests", Description = "Cover service layer", DueDate = new DateTime(2025, 09, 28), Priority = 1, IsCompleted = false, UserId = 3, ProjectId = 1 },
                new TaskItem { Id = 5, Title = "Setup CI/CD", Description = "Configure GitHub Actions", DueDate = new DateTime(2025, 09, 30), Priority = 2, IsCompleted = false, UserId = 1, ProjectId = 1 },
                new TaskItem { Id = 6, Title = "Frontend Integration", Description = "Connect React app", DueDate = new DateTime(2025, 10, 02), Priority = 3, IsCompleted = false, UserId = 2, ProjectId = 2 },
                new TaskItem { Id = 7, Title = "API Documentation", Description = "Generate Swagger docs", DueDate = new DateTime(2025, 09, 21), Priority = 1, IsCompleted = true, UserId = 1, ProjectId = 2 },
                new TaskItem { Id = 8, Title = "Database Migration", Description = "Apply EF Core migrations", DueDate = new DateTime(2025, 09, 19), Priority = 3, IsCompleted = true, UserId = 3, ProjectId = 2 },
                new TaskItem { Id = 9, Title = "Bug Fixing", Description = "Fix API endpoints", DueDate = new DateTime(2025, 09, 18), Priority = 2, IsCompleted = false, UserId = 2, ProjectId = 2 },
                new TaskItem { Id = 10, Title = "Final Testing", Description = "Run regression tests", DueDate = new DateTime(2025, 10, 05), Priority = 1, IsCompleted = false, UserId = 3, ProjectId = 2 }
            );
        }
    }
}


