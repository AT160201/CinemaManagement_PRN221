using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Rates = new HashSet<Rate>();
        }

        public int MovieId { get; set; }
        [Required(ErrorMessage = "Hãy điền tên phim")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hãy điền năm phát hành")]
        public int? Year { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }
}
