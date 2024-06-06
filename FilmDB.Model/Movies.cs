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
        public string Description { get; set; }

        public string Image { get; set; }
        public string Genre { get; set; }
		public int Year { get; set; }

        [ForeignKey(nameof(Director))]
		public int? DirectorID { get; set; }
        public Director? Director { get; set; }
      
       
    }
}
