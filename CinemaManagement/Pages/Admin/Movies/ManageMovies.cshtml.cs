using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Pages.Admin.Movies
{
    [BindProperties]
    public class ManageMoviesModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public ManageMoviesModel(CenimaDBContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Movie> Movies { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchByTitle { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (SearchByTitle!=null)
            {
                Movies = await _context.Movies.Where(x => x.Title.Contains(SearchByTitle)).Include(x => x.Genre).ToListAsync();
            }
            else
            {
                Movies = await _context.Movies.Include(m => m.Genre).ToListAsync();
            }
            Genres = await _context.Genres.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(Movie);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/Movies/ManageMovies");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int movieId)
        {
            var movie = await _context.Movies.FindAsync(movieId);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
