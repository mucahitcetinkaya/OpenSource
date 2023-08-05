using LessonWorld.Data.Concrete.EfCore.Configs;
using LessonWorld.Data.Concrete.EfCore.Extensions;
using LessonWorld.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LessonWorld.Data.Concrete.EfCore.Contexts
{
    public class LessonWorldContext :IdentityDbContext<User ,Role ,string>
    {
        public LessonWorldContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonCategory> LessonCategories { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfig).Assembly);
            
            base.OnModelCreating(modelBuilder);


        }
    }
}
