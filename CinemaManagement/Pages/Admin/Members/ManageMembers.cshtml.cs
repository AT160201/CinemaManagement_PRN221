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

        [BindProperty(SupportsGet = true)]
        public string SearchByNameMember { get; set; }

        public IActionResult OnGet()
        {
            if (SearchByNameMember!=null)
            {
                Members = _context.Persons.Where(x => x.Fullname.Contains(SearchByNameMember)).ToList();
            }
            else
            {
                Members = _context.Persons.ToList();
            }
            Member = new Person();
            return Page();
        }
    }
}
