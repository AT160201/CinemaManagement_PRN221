using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Pages.Admin.Genres
{
    public class EditGenreModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public EditGenreModel(CenimaDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Genre Genre { get; set; }

        public IActionResult OnGet(int genreId)
        {
            Genre = _context.Genres.Find(genreId);
            if (Genre == null)
            {
                return RedirectToPage("/Admin/Genres/ManageGenres");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Genre).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/Genres/ManageGenres");
            }
            else
            {
                return Page();
            }
        }
    }
}
