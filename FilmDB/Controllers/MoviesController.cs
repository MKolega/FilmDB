
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

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = _dbContext.Movies
                .Include(m => m.Director)
                .Where(m => m.ID == id)
                .FirstOrDefault();

			this.FillDropdownValues();
			return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]

        public async Task<IActionResult> EditPost(int id)
        {
            var movie = _dbContext.Movies
                .Include(m => m.Director)
                .Where(m => m.ID == id)
                .Single();
            var ok = await this.TryUpdateModelAsync(movie);

            if (ok && this.ModelState.IsValid)
            {
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            this.FillDropdownValues();
            return View();
        }

        [ActionName(nameof(Delete))]
        public async Task<IActionResult> Delete(int id)
        {
           
                var movie = _dbContext.Movies.Single(m => m.ID == id);
                var ok = await this.TryUpdateModelAsync(movie);
              
                    _dbContext.Movies.Remove(movie);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
               
        }

   
       
		private void FillDropdownValues()
		{
			var selectItems = new List<SelectListItem>();

			
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
            var selectDirectors = new List<SelectListItem>();


           
            listItem.Text = "- Choose -";
            listItem.Value = "";
            selectDirectors.Add(listItem);
            foreach (var director in _dbContext.Director)
            {
                if (!selectDirectors.Any(item => item.Value == director.Name))
                {
                    listItem = new SelectListItem(director.Name, director.ID.ToString());
                    selectDirectors.Add(listItem);
                }
             
            }

            ViewBag.PossibleDirectors = selectDirectors;
        }

	}
}
