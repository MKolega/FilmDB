namespace FilmDB.Web.Models
{
	public class MoviesDTO
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
	
		public string? Image { get; set; }
	
		public string? Genre { get; set; }

		public int Year { get; set; }
		public DirectorDTO? Director { get; set; }
		
	}
}
