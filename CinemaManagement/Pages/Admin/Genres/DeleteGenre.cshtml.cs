using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaManagement.Pages.Admin.Genres
{
    public class DeleteGenreModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public DeleteGenreModel(CenimaDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int genreId)
        {
            Genre = await _context.Genres.FindAsync(genreId);
            if (Genre != null)
            {
                _context.Genres.Remove(Genre);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Genres/ManageGenres");
        }
    }
}
