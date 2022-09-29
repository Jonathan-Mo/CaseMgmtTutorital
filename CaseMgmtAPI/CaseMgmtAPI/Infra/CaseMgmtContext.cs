using CaseMgmtAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Infra
{
    public class CaseMgmtContext : DbContext
    {
        public CaseMgmtContext(DbContextOptions<CaseMgmtContext> options) : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Reporter> Reporters { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Case>().HasData(
        //        new Child()
        //        {
        //            Id = 1,
        //            FirstName = "Emily",
        //            LastName = "Johnson",
        //            StreetAddress = "2323 Wayford Place",
        //            City = 2,
        //            State = 3,
        //            ZipCode = "70808",
        //            Details = "Information information information."
        //        },
        //        new Child()
        //        {
        //            Id = 2,
        //            FirstName = "Jacob",
        //            LastName = "Mendez",
        //            StreetAddress = "2323 Wayford Place",
        //            City = 2,
        //            State = 3,
        //            ZipCode = "70808",
        //            Details = "Information information information."
        //        },
        //        new Child()
        //        {
        //            Id = 3,
        //            FirstName = "Drake",
        //            LastName = "Eisenhower",
        //            StreetAddress = "2323 Wayford Place",
        //            City = 2,
        //            State = 3,
        //            ZipCode = "70808",
        //            Details = "Information information information."
        //        });

        //    modelBuilder.Entity<Reporter>().HasData(
        //        new Reporter()
        //        {
        //            Id = 1,
        //            FirstName = "Reporter1First",
        //            LastName = "Reporter1Last",
        //            Email = "Reporter1Email@gmail.com",
        //            Phone = "Reporter1Phone"
        //        },
        //        new Reporter()
        //        {
        //            Id = 2,
        //            FirstName = "Reporter2First",
        //            LastName = "Reporter2Last",
        //            Email = "Reporter2Email@gmail.com",
        //            Phone = "Reporter2Phone"
        //        },
        //        new Reporter()
        //        {
        //            Id = 3,
        //            FirstName = "Reporter3First",
        //            LastName = "Reporter3Last",
        //            Email = "Reporter3Email@gmail.com",
        //            Phone = "Reporter3Phone"
        //        });

        //    modelBuilder.Entity<Case>().HasData(
        //        new Case()
        //        {
        //            Id = 1,
        //            ChildId = 1,
        //            ReporterId = 1,
        //            IsDeleted = false
        //        });

        //    modelBuilder.Entity<Employee>().HasData(
        //       new Employee()
        //       {
        //           Id = 1,
        //           FirstName = "EFN",
        //           LastName = "ELN"
        //       });
        //}
    }
}
