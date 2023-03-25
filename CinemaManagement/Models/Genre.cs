using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int GenreId { get; set; }

        // Description is not null
        [Required(ErrorMessage = "Hãy điền mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
