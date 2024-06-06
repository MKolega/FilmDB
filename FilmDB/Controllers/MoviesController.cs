
using FilmDB.DAL;
using FilmDB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
                .Include(m => m.Director)
                .Where(m => m.ID == id)
                .FirstOrDefault();

            return View(movie);
        }
		
		public IActionResult Create()
        {
			this.FillDropdownValues();
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
            this.FillDropdownValues();
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var model = _dbContext.Movies.FirstOrDefault(m => m.ID == id);
			this.FillDropdownValues();
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

            this.FillDropdownValues();
            return View();
        }
		private void FillDropdownValues()
		{
			var selectItems = new List<SelectListItem>();

			//Polje je opcionalno
			var listItem = new SelectListItem();
			listItem.Text = "- Choose -";
			listItem.Value = "";
			selectItems.Add(listItem);

			// Add genres to the list
			selectItems.Add(new SelectListItem("Action", "Action"));
			selectItems.Add(new SelectListItem("Horror", "Horror"));
			selectItems.Add(new SelectListItem("Thriller", "Thriller"));
			selectItems.Add(new SelectListItem("Romance", "Romance"));
			selectItems.Add(new SelectListItem("Drama", "Drama"));
			selectItems.Add(new SelectListItem("Comedy", "Comedy"));
          
			foreach (var category in _dbContext.Movies)
			{
				if (!selectItems.Any(item => item.Value == category.Genre))
				{
					listItem = new SelectListItem(category.Genre, category.ID.ToString());
					selectItems.Add(listItem);
				}
			}

			ViewBag.PossibleGenres = selectItems;
		}

	}
}
