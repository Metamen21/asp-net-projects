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
    public class IndexModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDbContext _context;

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string bookCategorySort { get; set; }
        public string ReleaseDateSort { get; set; }
        public string RatingSort { get; set; }
        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }

        public IndexModel(DemoLibWorld.DataLayer.BookDbContext context)
        {
            _context = context;
        }

        public PaginationList<BookEntity> BookEntity { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString,int? pageIndex)
        {
            if (_context.BookCollections != null)
            {
                TitleSort = sortOrder == "title_asc_sort" ? "title_desc_sort" : "title_asc_sort";
                AuthorSort = sortOrder == "author_asc_sort" ? "author_desc_sort" : "author_asc_sort";
                bookCategorySort = sortOrder == "bookcategory_asc_sort" ? "bookcategory_desc_sort" : "bookcategory_asc_sort";
                RatingSort = sortOrder == "rating_asc_sort" ? "rating_desc_sort" : "rating_asc_sort";
                DateSort = sortOrder == "Date" ? "date_desc" : "Date";




                //if (!string.IsNullOrEmpty(searchString))
                //{
                //    BookEntity = await _context.BookCollections.Where(s => s.Title.Contains(searchString)
                //    || s.Authorname.Contains(searchString) || s.BookCategories.BookCategoryName.Contains(searchString)).ToListAsync();
                //}
                //else
                //{
                //    BookEntity = await _context.BookCollections.ToListAsync();
                //}

                IQueryable<BookEntity> bookIQ = from s in _context.BookCollections
                                                select s;

                foreach (var obj in bookIQ)
                {
                    obj.BookCategories = await _context.BookCategories.FirstOrDefaultAsync(x =>
                    x.BookCategoryId == obj.BookCategoryId);
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    bookIQ = bookIQ.Where(s => s.Title.Contains(searchString)
                    || s.Authorname.Contains(searchString) || s.BookCategories.BookCategoryName.Contains(searchString));
                }

                //foreach (var obj in BookEntity)
                //{
                //    obj.BookCategories = await _context.BookCategories.FirstOrDefaultAsync(x =>
                //    x.BookCategoryId == obj.BookCategoryId);
                //}

                switch (sortOrder)
                {
                    case "title_asc_sort":
                        bookIQ.OrderBy(s => s.Title);
                        break;
                    case "title_desc_sort":
                        bookIQ.OrderByDescending(s => s.Title);
                        break;
                    case "author_asc_sort":
                        bookIQ.OrderBy(s => s.Authorname);
                        break;
                    case "author_desc_sort":
                        bookIQ.OrderByDescending(s => s.Authorname);
                        break;
                    //case "bookcategory_asc_sort":
                    //    BookEntity.OrderBy(s => s.BookCategories.BookCategoryName).ToList();
                    //    break;
                    //case "bookcategory_desc_sort":
                    //    BookEntity.OrderByDescending(s => s.BookCategories.BookCategoryName).ToList();
                    //    break;
                    //case "rating_asc_sort":
                    //    BookEntity.OrderBy(s => s.Rating).ToList();
                    //    break;
                    //case "rating_desc_sort":
                    //    BookEntity.OrderByDescending(s => s.Rating).ToList();
                    //    break;
                    //case "Date":
                    //    BookEntity.OrderBy(s => s.Releasedate).ToList();
                    //    break;
                    //case "date_desc":
                    //    BookEntity.OrderByDescending(s => s.Releasedate).ToList();
                    //    break;
                    default:
                        bookIQ = bookIQ.OrderBy(s => s.Title);
                        break;

                }
                var pageSize = 2;
                BookEntity=await PaginationList<BookEntity>.CreateAsync(
                    bookIQ,pageIndex ?? 1,pageSize);
            }
        }
    }
}
