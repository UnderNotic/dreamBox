using System.Data.Entity;
using LoveMeBetter.Models.Identity;
using LoveMeBetter.Models.Order;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoveMeBetter.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Order.Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Product> Product { get; set; } 

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}