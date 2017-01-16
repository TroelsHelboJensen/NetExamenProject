using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Here i can add variables to the ApplicationUser
        //public int userInfoId { get; set; }
        //public UserModel userInfo { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Entity Framework Tables
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProgressModel> Progress { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UnitTestingMockUps.Models.Entity.CategoryHeaderModel> CategoryHeaders { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}