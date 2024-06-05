
using FilmDB.Model;
using Microsoft.EntityFrameworkCore;
namespace FilmDB.DAL
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext() { }
                public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().HasData(new Movies { ID = 1, Title = "Furiosa: A Mad Max Saga", Description = "Temp" , Genre = "Action", Image= "https://m.media-amazon.com/images/M/MV5BNmYzMWVjNmQtNjJjNy00M2Y4LTkzZjQtZWQ5NmYzMjRjMDIzXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY576_.jpg", Director = "George Miller", Year=2024 });
            modelBuilder.Entity<Movies>().HasData(new Movies { ID = 2, Title = "Deadpool & Wolverine", Description = "Temp", Genre = "Action", Image = "https://m.media-amazon.com/images/M/MV5BN2YxYTFmYTMtZjQ0YS00YTViLTg2OWEtMmM5YzY0YTE4OTU5XkEyXkFqcGdeQXVyMTY3ODkyNDkz._V1_FMjpg_UY720_.jpg", Director = "Shawn Levy", Year = 2024 });
            modelBuilder.Entity<Movies>().HasData(new Movies { ID = 3, Title = "Fall Guy", Description = "Temp" , Genre = "Action", Image= "https://m.media-amazon.com/images/M/MV5BMjA5ZjA3ZjMtMzg2ZC00ZDc4LTk3MTctYTE1ZTUzZDIzMjQyXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY720_.jpg", Director = "David Leitch", Year=2024 });
           
}
    }
}
