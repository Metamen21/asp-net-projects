using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDbContext _context;

        public CreateModel(DemoLibWorld.DataLayer.BookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookCategories.Add(BookCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
