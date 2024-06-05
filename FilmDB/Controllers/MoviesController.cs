
using FilmDB.DAL;
using FilmDB.Model;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var model = _dbContext.Movies.FirstOrDefault(m => m.ID == id);
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(int id)
        {
            var client = _dbContext.Movies.Single(m => m.ID == id);
            var ok = await this.TryUpdateModelAsync(client);

            if (ok && this.ModelState.IsValid)
            {
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            
            return View();
        }
    }
}
