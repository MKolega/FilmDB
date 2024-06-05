using Microsoft.EntityFrameworkCore;

namespace FilmDB.DAL
{
    public class FilmDbContext : DbContext
    {
        protected FilmDbContext()
        {
        }
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {
        }
    }
}
