using Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

            //modelBuilder.Entity<IdentityUser>().ToTable("Users");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            //modelBuilder.Entity<ApplicationUser>(b =>
            //{
            //    // Each User can have many UserClaims
            //    b.HasMany(e => e.Claims)
            //        .WithOne(e => e.User)
            //        .HasForeignKey(uc => uc.UserId)
            //        .IsRequired();

            //    // Each User can have many UserLogins
            //    b.HasMany(e => e.Logins)
            //        .WithOne(e => e.User)
            //        .HasForeignKey(ul => ul.UserId)
            //        .IsRequired();

            //    // Each User can have many UserTokens
            //    b.HasMany(e => e.Tokens)
            //        .WithOne(e => e.User)
            //        .HasForeignKey(ut => ut.UserId)
            //        .IsRequired();

            //    // Each User can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne(e => e.User)
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //});

            //modelBuilder.Entity<ApplicationRole>(b =>
            //{
            //    // Each Role can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne(e => e.Role)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();

            //    // Each Role can have many associated RoleClaims
            //    b.HasMany(e => e.RoleClaims)
            //        .WithOne(e => e.Role)
            //        .HasForeignKey(rc => rc.RoleId)
            //        .IsRequired();
            //});
        }
    }
    
}
