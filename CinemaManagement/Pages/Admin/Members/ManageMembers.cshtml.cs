using CinemaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Pages.Admin.Members
{
    [BindProperties]
    public class ManageMembersModel : PageModel
    {
        private readonly CenimaDBContext _context;

        public ManageMembersModel(CenimaDBContext context)
        {
            _context = context;
        }

        public List<Person> Members { get; set; }
        public Person Member { get; set; }

        public IActionResult OnGet()
        {
            Members = _context.Persons.ToList();
            Member = new Person();
            return Page();
        }
    }
}
