
using FilmDB.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FilmDB.DAL
{
    public class FilmDbContext : IdentityDbContext<AppUser>
    {
        public FilmDbContext() { }
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Director>().HasData(new Director { ID = 1, Name = "George Miller", Bio = "Temp", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/George_Miller_%2835706244922%29.jpg/800px-George_Miller_%2835706244922%29.jpg" });
			modelBuilder.Entity<Director>().HasData(new Director { ID = 2, Name = "Shawn Levy", Bio = "Temp", Image = "https://en.wikipedia.org/wiki/File:Shawn_Levy_by_Gage_Skidmore_2.jpg" });
			modelBuilder.Entity<Director>().HasData(new Director { ID = 3, Name = "David Leitch", Bio = "Temp", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/David_Leitch_by_Gage_Skidmore_2.jpg/330px-David_Leitch_by_Gage_Skidmore_2.jpg" });
			modelBuilder.Entity<Movies>().HasData(new Movies { ID = 1, Title = "Furiosa: A Mad Max Saga", Description = "Temp", Genre = "Action", Image = "https://m.media-amazon.com/images/M/MV5BNmYzMWVjNmQtNjJjNy00M2Y4LTkzZjQtZWQ5NmYzMjRjMDIzXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY576_.jpg", Year = 2024 , DirectorID = 1 });
            modelBuilder.Entity<Movies>().HasData(new Movies { ID = 2, Title = "Deadpool & Wolverine", Description = "Temp", Genre = "Action", Image = "https://m.media-amazon.com/images/M/MV5BN2YxYTFmYTMtZjQ0YS00YTViLTg2OWEtMmM5YzY0YTE4OTU5XkEyXkFqcGdeQXVyMTY3ODkyNDkz._V1_FMjpg_UY720_.jpg", Year = 2024 , DirectorID = 2 });
			modelBuilder.Entity<Movies>().HasData(new Movies { ID = 3, Title = "Fall Guy", Description = "Temp", Genre = "Action", Image = "https://m.media-amazon.com/images/M/MV5BMjA5ZjA3ZjMtMzg2ZC00ZDc4LTk3MTctYTE1ZTUzZDIzMjQyXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY720_.jpg", Year = 2024, DirectorID = 3 });
			
		}
    }
}
