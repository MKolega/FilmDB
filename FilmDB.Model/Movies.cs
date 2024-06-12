using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmDB.Model
{
    public class Movies
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
		public int Year { get; set; }

        [ForeignKey(nameof(Director))]
		public int? DirectorID { get; set; }
        public Director? Director { get; set; }
      
       
    }
}
