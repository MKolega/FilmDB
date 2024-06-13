using FilmDB.DAL;
using Microsoft.AspNetCore.Mvc;
using FilmDB.Model;
using FilmDB.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace FilmDB.Web.Controllers
{
	[Route("api/movies")]
	[ApiController]
	public class MoviesApiController(FilmDbContext _dbContext) : Controller
	{
		[ProducesResponseType(200, Type = typeof(List<MoviesDTO>))]
		public IActionResult Get()
		{
			var movies = _dbContext.Movies.ToList();
			var dtos = movies.Select(MapFromMovies).ToList();
			return Ok(movies);
		}

		[ProducesResponseType(200, Type = typeof(MoviesDTO))]
		[Route("{id}")]
		public IActionResult GetID(int? id)
		{
			var movie = _dbContext.Movies
				.Include(m => m.Director)
				.Where(m => m.ID == id)
				.FirstOrDefault();

			if (movie == null)
			{ 
				return NotFound(); 
			}
			else
			{
				var dto = MapFromMovies(movie);
				return Ok(dto);
			}
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<ActionResult<MoviesDTO>> Put(int id, [FromBody] Movies model)
		{
			if (id != model.ID)
			{
				return BadRequest();
			}

			var movie = await _dbContext.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound();
			}

			movie.Title = model.Title;
			movie.Description = model.Description;
			movie.DirectorID = model.DirectorID;

			try
			{
				await _dbContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MovieExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			var dto = MapFromMovies(movie);
			return Ok(dto);
		}

		private bool MovieExists(int id)
		{
			throw new NotImplementedException();
		}

		[HttpDelete]
		[Route("{id}")]

		public IActionResult Delete(int id)
		{
			var movie = _dbContext.Movies.Find(id);
			if (movie == null)
			{
				return NotFound();
			}

			_dbContext.Movies.Remove(movie);
			_dbContext.SaveChanges();
			return Ok();
		}

		[HttpPost]
		public IActionResult Post([FromBody] Movies model)
		{
			var movies = new Movies();
			{
				
				movies.Title = model.Title;
				movies.Description = model.Description;
				movies.Image = model.Image;
				movies.Genre = model.Genre;
				movies.Year = model.Year;
				movies.DirectorID = model.DirectorID;
				

			}
			_dbContext.Movies.Add(model);
			_dbContext.SaveChanges();
			return CreatedAtAction(nameof(GetID), new { id = model.ID }, model);
		}

		private MoviesDTO MapFromMovies(Movies movies)
		{
			var dto = new MoviesDTO();
			{
				dto.ID = movies.ID;
				dto.Title = movies.Title;
				dto.Description = movies.Description;
				if(movies.Director != null)
				{
					dto.Director = new DirectorDTO
					{
						ID = movies.Director.ID,
						Name = movies.Director.Name
					};
				}
				return dto;

			}
		}
	}
}
