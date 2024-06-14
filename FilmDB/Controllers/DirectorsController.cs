
using FilmDB.DAL;
using FilmDB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Web.Controllers
{
	public class DirectorsController(FilmDbContext _dbContext) : Controller
	{
		public IActionResult Index()
		{
			var directorQuery = _dbContext.Director.AsQueryable();
			return View(directorQuery.ToList());
		}
		public IActionResult Details(int? id = null)
		{
            var director = _dbContext.Director
                .Include(d => d.Movies)
                .Where(d => d.ID == id)
                .FirstOrDefault();

            return View(director);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Director.Add(director);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
         
            return View(director);
        }

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = _dbContext.Director
                .Include(m => m.Movies)
                .Where(m => m.ID == id)
                .FirstOrDefault();

        
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]

        public async Task<IActionResult> EditPost(int id)
        {
            var director = _dbContext.Director
                .Include(m => m.Movies)
                .Where(m => m.ID == id)
                .Single();
            var ok = await this.TryUpdateModelAsync(director);

            if (ok && this.ModelState.IsValid)
            {
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

          
            return View();
        }
    }
}
