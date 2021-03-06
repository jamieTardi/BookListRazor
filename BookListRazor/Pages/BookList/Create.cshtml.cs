using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        //On post redirect to another page.
        public async Task<IActionResult> OnPost(Book bookObj)
        {
            try
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch
            {
             return Page();
            }
        }
    }
}
