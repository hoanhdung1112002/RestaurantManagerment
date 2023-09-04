using Microsoft.EntityFrameworkCore;
using WebQuanLyNhaHang.Areas.Admin.Models;

namespace WebQuanLyNhaHang.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFooter> MenuFooter { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<ViewFoodDetails> ViewFoodDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        //DB: Admin
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
