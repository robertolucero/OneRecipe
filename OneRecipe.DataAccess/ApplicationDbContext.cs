using Microsoft.EntityFrameworkCore;
using OneRecipe.Model;


namespace OneRecipe.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>();
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Ingredients)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>();

            modelBuilder.Seed();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
