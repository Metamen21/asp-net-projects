using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDbContext _context;

        public DetailsModel(DemoLibWorld.DataLayer.BookDbContext context)
        {
            _context = context;
        }

        public BookEntity BookEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCollections == null)
            {
                return NotFound();
            }

            var bookentity = await _context.BookCollections.FirstOrDefaultAsync(m => m.BookId == id);

            bookentity.BookCategories = await _context.BookCategories.FirstOrDefaultAsync(x =>
            x.BookCategoryId == bookentity.BookCategoryId);
            if (bookentity == null)
            {
                return NotFound();
            }
            else
            {
                BookEntity = bookentity;
            }
            return Page();
        }
    }
}
