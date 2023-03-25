using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaManagement.Pages.Admin.Movies
{
    public class DeleteMovieModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public DeleteMovieModel(CenimaDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int movieId)
        {
            Movie = await _context.Movies.FindAsync(movieId);
            if (Movie != null)
            {
                _context.Movies.Remove(Movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Movies/ManageMovies");
        }
    }
}
