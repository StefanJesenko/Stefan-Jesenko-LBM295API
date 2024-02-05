using Microsoft.EntityFrameworkCore;

namespace Stefan_Jesenko_LBM295API.Models
{
    public class PizzaDB : DbContext

    {
       
        public DbSet<Pizza> Pizzen { get; set; }
        public DbSet<Zutaten> Zutaten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaDb;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);

        }
        
    }
}
