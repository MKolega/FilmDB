using System.ComponentModel.DataAnnotations;

namespace FilmDB.Model
{
    public class Movies
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
       
    }
}
