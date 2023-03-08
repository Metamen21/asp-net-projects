using System.ComponentModel.DataAnnotations;

namespace DemoLibWorld.Entity
{
    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }
        [Display(Name = "Category")]
        public string BookCategoryName { get; set; }
    }
}
