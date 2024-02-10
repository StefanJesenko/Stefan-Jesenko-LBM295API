using Microsoft.EntityFrameworkCore;

namespace Stefan_Jesenko_LBM295API.Models
{
    public class PizzaDB : DbContext

    {
       
        public DbSet<Pizza> Pizzen { get; set; }
        public DbSet<Zutaten> Zutaten { get; set; }
        public DbSet<PizzaZutaten> PizzaZutaten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaDb;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<PizzaZutaten>()
                .HasOne<Pizza>()
                .WithMany()
                .HasForeignKey(pz => pz.PizzaId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<PizzaZutaten>()
                .HasOne<Zutaten>()
                .WithMany()
                .HasForeignKey(pz => pz.ZutatenId)
                .OnDelete(DeleteBehavior.Cascade); 
        }


    }
}
