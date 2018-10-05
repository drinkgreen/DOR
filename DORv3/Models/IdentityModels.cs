using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using DORv3.DAL.Models;

namespace DORv3.Models
{
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public ApplicationUser()
    //    {

    //    }

    //    public ApplicationUser(string username) : base(username)
    //    {

    //    }
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    //public class FowlerUser : ApplicationUser
    //{
    //    //public int Id { get; set; }
    //    //public string Email { get; set; }
    //    //public string UserName { get; set; }
    //    //public string PasswordHash { get; set; }
    //    //public string SecurityStamp { get; set; }
    //    //public string PasswordOld { get; set; }
    //    //public DateTime DateCreated { get; set; }
    //    //public bool Activated { get; set; }
    //    //public bool UserRole { get; set; }
    //}

    //public class FowlerRole : IdentityRole
    //{
    //}

    //public class DorDBContext : IdentityDbContext<ApplicationUser>
    //{
    //    public DorDBContext()
    //        : base("FowlerDORContext", throwIfV1Schema: false)
    //    {
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<ApplicationUser>().Ignore(x => x.PhoneNumberConfirmed);
    //        modelBuilder.Entity<ApplicationUser>().Ignore(x => x.EmailConfirmed);
    //       // modelBuilder.Entity<ApplicationUser>().Property(p=>)

    //        //modelBuilder.Entity<FowlerUser>()
    //        //    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("UniqueKey");

    //        //modelBuilder.Entity<FowlerRole>()
    //        //    .ToTable("Roles", "dbo").Property(p => p.Id).HasColumnName("ID");
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("FowlerDORContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo").Property(p => p.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<ApplicationUser>().Ignore(x => x.PhoneNumberConfirmed);
           // modelBuilder.Entity<ApplicationUser>().Ignore(x => x.SecurityStamp);
            modelBuilder.Entity<ApplicationUser>().Ignore(x => x.TwoFactorEnabled);
            // modelBuilder.Entity<ApplicationUser>().Property(p=>)

            //modelBuilder.Entity<FowlerUser>()
            //    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("UniqueKey");

            //modelBuilder.Entity<FowlerRole>()
            //    .ToTable("Roles", "dbo").Property(p => p.Id).HasColumnName("ID");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}