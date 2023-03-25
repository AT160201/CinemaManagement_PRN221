using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaManagement.Pages.Admin.Members
{
    public class DeactiveMemberModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public DeactiveMemberModel(CenimaDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int personId)
        {
            Person = await _context.Persons.FindAsync(personId);
            if (Person != null)
            {
                Person.IsActive = false;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Members/ManageMembers");
        }
    }
}
