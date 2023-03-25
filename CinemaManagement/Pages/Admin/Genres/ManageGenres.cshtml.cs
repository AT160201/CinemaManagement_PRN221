using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaManagement.Pages.Admin.Genres
{
    [BindProperties]
    public class ManageGenresModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public ManageGenresModel(CenimaDBContext context)
        {
            _context = context;
        }
        public List<Genre> Genres { get; set; }
        public Genre Genre { get; set; }

        public IActionResult OnGet()
        {
            Genres = _context.Genres.ToList();
            Genre = new Genre();
            return Page();
        }

        // Action method to handle search request
        public IActionResult OnPostSearchGenres(string search)
        {
            var filteredGenres = _context.Genres.Where(g => g.Description.Contains(search)).ToList();
            return Partial("_GenresTable", filteredGenres);
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Genres.Add(Genre);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/Genres/ManageGenres");
            }
            else
            {
                return RedirectToPage("/Admin/Genres/ManageGenres");
            }
        }
    }
}
