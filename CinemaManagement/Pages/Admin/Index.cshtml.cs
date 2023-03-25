using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly CenimaDBContext _db;
        public IndexModel(CenimaDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int totalCategory { get; set; }
        public int totalMovie { get; set; }
        public int totalMember { get; set; }
        public int totalRate { get; set; }
        public List<Genre> genres { get; set; }

        public List<Rate> rates { get; set; }
        public List<Movie> movies { get; set; }
        public Movie movie { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int PageSize = 3;

        public int TotalPages { get; set; }

        public int CurrentPage2 { get; set; } = 1;

        public int PageSize2 = 3;

        public int TotalPages2 { get; set; }
        public void OnGet()
        {
            totalCategory = _db.Genres.Count();
            totalMember = _db.Persons.Count();
            totalMovie = _db.Movies.Count();
            totalRate = _db.Rates.Count();
            genres = _db.Genres.Include("Movies").Skip((CurrentPage2 - 1) * PageSize2).Take(PageSize2).ToList();
            rates = _db.Rates.Include("Person").Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            movies = _db.Movies.ToList();
            movie = null;
            TotalPages = _db.Rates.ToList().Count() / PageSize;
            if (_db.Rates.ToList().Count() <= PageSize)
            {
                TotalPages = 0;
            }
            TotalPages2 = _db.Genres.ToList().Count() / PageSize2;
            if (_db.Genres.ToList().Count() <= PageSize2)
            {
                TotalPages2 = 0;
            }
        }

        public void OnPost()
        {            
               
            string mId = Request.Form["movie"];
            string page = Request.Form["page"];
            if(page != null)
            {
                CurrentPage = int.Parse(page);
            }
            else { CurrentPage = 1; }
            string page2 = Request.Form["page2"];
            if (page2 != null)
            {
                CurrentPage2 = int.Parse(page2);
            }
            else { CurrentPage2 = 1; }
            totalCategory = _db.Genres.Count();
            totalMember = _db.Persons.Count();
            totalMovie = _db.Movies.Count();
            totalRate = _db.Rates.Count();
            genres = _db.Genres.Include("Movies").Skip((CurrentPage2 - 1) * PageSize2).Take(PageSize2).ToList();
            if (int.Parse(mId) == 0)
            {
                rates = _db.Rates.Include("Person").Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
                movie = null;
                TotalPages = _db.Rates.ToList().Count() / PageSize;
            }
            else
            {
                rates = _db.Rates.Include("Person").Where(r => r.MovieId == int.Parse(mId))
                    .Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
                movie = _db.Movies.Where(m => m.MovieId == int.Parse(mId)).SingleOrDefault();
                TotalPages = _db.Rates.Where(r => r.MovieId == int.Parse(mId)).ToList().Count() / PageSize;
            }
            if(_db.Rates.ToList().Count() <= PageSize)
            {
                TotalPages = 0;
            }
            movies = _db.Movies.ToList();

            TotalPages2 = _db.Genres.ToList().Count() / PageSize2;
            if (_db.Genres.ToList().Count() <= PageSize2)
            {
                TotalPages2 = 0;
            }
        }
    }
}
