using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDbContext _context;

        public List<SelectListItem> GetBookCategories { get; set; }                    

        public CreateModel(DemoLibWorld.DataLayer.BookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            GetBookCategories = _context.BookCategories.Select(i => new SelectListItem
            {
                Text = i.BookCategoryName,
                Value = i.BookCategoryId.ToString()
            }).ToList();
            return Page();
        }

        [BindProperty]
        public BookEntity BookEntity { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookCollections.Add(BookEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
