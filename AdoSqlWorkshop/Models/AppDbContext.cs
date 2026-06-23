using Microsoft.EntityFrameworkCore;

namespace AdoSqlWorkshop.Models
{
    // Using Fluent API
    public class AppDbContext : DbContext
    {

        // Map models
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }

        // Fluent API model config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // -- Map Table: Courses -- //
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Code)
                    .IsRequired() // Not null
                    .HasMaxLength(10); // VARCHAR(10)

                entity.Property(e => e.Name)
                    .IsRequired() // Not null
                    .HasMaxLength(50); // VARCHAR(50)

                entity.Property(e => e.Description)
                    .IsRequired() // Not null
                    .HasMaxLength(300); // VARCHAR(300)
            });

            // -- Map Table: Lecturers -- //
            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturers");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                    .IsRequired() // Not null
                    .HasMaxLength(50); // VARCHAR(50)

                entity.Property(e => e.LastName)
                    .IsRequired() // Not null
                    .HasMaxLength(50); // VARCHAR(50)

                entity.Property(e => e.Username)
                    .IsRequired() // Not null
                    .HasMaxLength(50); // VARCHAR(50)

            });

        }

    }
}
