using Data;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : this(
            new DbContextOptionsBuilder<ApplicationDbContext>().Options)
        { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<AddressData> Addresses { get; set; }
        public DbSet<ContactData> Contacts { get; set; }
        public DbSet<ContractData> Contracts { get; set; }
        public DbSet<DepartmentData> Departments { get; set; }
        public DbSet<LocationData> Locations { get; set; }
        public DbSet<OccupationData> Occupations { get; set; }
        public DbSet<PartyContactData> PartyContacts { get; set; }
        public DbSet<PersonData> Persons { get; set; }
        public DbSet<RequirementData> Requirements { get; set; }
        public DbSet<ShiftAssignmentData> ShiftAssignments { get; set; }
        public DbSet<StandardShiftData> StandardShifts { get; set; }
        public DbSet<WeekDayData> WeekDays { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AddressData>().ToTable("Address");
            modelBuilder.Entity<ContactData>().ToTable("Contact");
            modelBuilder.Entity<ContractData>().ToTable("Contract");
            modelBuilder.Entity<DepartmentData>().ToTable("Department");
            modelBuilder.Entity<LocationData>().ToTable("Location");
            modelBuilder.Entity<OccupationData>().ToTable("Occupation");
            modelBuilder.Entity<PartyContactData>().ToTable("PartyContact");
            modelBuilder.Entity<PersonData>().ToTable("Person");
            modelBuilder.Entity<RequirementData>().ToTable("Requirement");
            modelBuilder.Entity<ShiftAssignmentData>().ToTable("ShiftAssignment");
            modelBuilder.Entity<StandardShiftData>().ToTable("StandardShift");
            modelBuilder.Entity<WeekDayData>().ToTable("WeekDay");
        }
    }
    
}
