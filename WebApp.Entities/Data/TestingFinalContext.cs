using Microsoft.EntityFrameworkCore;
using WebApp.Entities.Models;

namespace WebApp.Entities.Data;

public class TestingFinalContext : DbContext
{
    public TestingFinalContext(DbContextOptions<TestingFinalContext> options) : base(options)
    {
    }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=> optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.HasIndex(e => e.Role1, "role_role_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1)
                .HasMaxLength(30)
                .HasColumnName("role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdtime");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Lastmodifiedtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastmodifiedtime");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.InverseCreatedbyNavigation)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("fk_createdby");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.InverseModifiedbyNavigation)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("fk_modifiedby");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_role_id");
        });

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Role1 = "Admin" },
            new Role { Id = 2, Role1 = "User" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "dhruvsavsani1", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 1, Createdby = 1, Modifiedby = 1, Isdeleted = false},
            new User { Id = 2, Username = "dhruvsavsani2", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 3, Username = "dhruvsavsani3", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 4, Username = "dhruvsavsani4", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 5, Username = "dhruvsavsani5", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 6, Username = "dhruvsavsani6", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 7, Username = "dhruvsavsani7", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 8, Username = "dhruvsavsani8", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 9, Username = "dhruvsavsani9", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 10, Username = "dhruvsavsani10", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 11, Username = "dhruvsavsani11", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false },
            new User { Id = 12, Username = "dhruvsavsani12", Password = "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", RoleId = 2, Createdby = 1, Modifiedby = 1, Isdeleted = false }
        );

    }
}
