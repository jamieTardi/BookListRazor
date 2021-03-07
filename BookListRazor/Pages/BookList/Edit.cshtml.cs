using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        //this is needed to update the DB
        private ApplicationDbContext _db;

        //the constructor method allowing the item to be edited
        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty]

        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                //Pass the book id so this book can be updated
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Author = Book.Author;
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            catch
            {
                return RedirectToPage();
            }
           
        }
    }
}
