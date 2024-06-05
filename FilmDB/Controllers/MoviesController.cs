
using FilmDB.DAL;
using FilmDB.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Web.Controllers
{
    public class MoviesController(FilmDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
           
            var movieQuery = _dbContext.Movies.AsQueryable();
            return View(movieQuery.ToList());
        }
        public IActionResult Details(int? id = null)
        {
            var movie = _dbContext.Movies
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(movie);
        }


    }
}
