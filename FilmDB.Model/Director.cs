using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Model
{
	public class Director
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		public string Bio { get; set; }
		public string Image { get; set; }

		public ICollection<Movies>? Movies { get; set; }
		
	}
}
