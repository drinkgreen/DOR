using System;
using Microsoft.Owin;
using Owin;
using DORv3.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using DORv3.Models;
//using DORv3.Models;

[assembly: OwinStartupAttribute(typeof(DORv3.Startup))]
namespace DORv3
{
    public partial class Startup
    {
        FowlerDORContext context;
        User user;
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // context = new FowlerDORContext();

            //CreateUsers();
            //CreateRoles();
          // CreateIdentityUser();
        }

        private void CreateIdentityUser()
        {
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationDbContext context = new ApplicationDbContext();

            string password = "fowler2018";
            var manager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));
            var user = new ApplicationUser()
            {
                UserName = "testuser3",
                Email = "test3@test.com",
                PasswordHash = password
            }; 

            var chkUser = manager.Create(user);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
               // var result1 = manager.AddToRole(user.Id, "Admin");

            }
            // await manager

            //var chkUser = UserManager.Create(user, password);

            //Add default User to Role Admin    

        }

        private void CreateRoles()
        {
            user = context.Users.Where(u => u.Email == user.Email).First();

            var role = new XRef_UserDealershipRoles
            {
                UserID = user.ID,
                DealershipID = 99,
                RoleID = 1,
                CreatedBy = "drinkgreen@hotmail.com",
                CreatedDate = DateTime.Now
            };

            context.XRef_UserDealershipRoles.Add(role);

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        private void CreateUsers()
        {
            user = new User
            {
                Email = "siteadmin@fowlerholding.com",
                Password = "Password",
            };

            context.Users.Add(user);
            
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }
}
