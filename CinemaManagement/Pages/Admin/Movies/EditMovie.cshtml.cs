using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Pages.Admin.Movies
{
    [BindProperties]
    public class EditMovieModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public EditMovieModel(CenimaDBContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public List<Genre> AllGenres { get; set; }

        public async Task<IActionResult> OnGetAsync(int movieId)
        {
            Movie = await _context.Movies.FindAsync(movieId);

            if (Movie == null)
            {
                return NotFound();
            }
            AllGenres = await _context.Genres.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AllGenres = await _context.Genres.ToListAsync();
                return Page();
            }
            _context.Attach(Movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/Movies/ManageMovies");
        }
    }
}
