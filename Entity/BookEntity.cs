using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DemoLibWorld.Entity
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter Title name. It's Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title name is too short. please enter valid title name")]
        public string Title { get; set; }
        [Display(Name = "Author Name")]
        [Required(ErrorMessage = "Please enter Title name. It's Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title name is too short. please enter valid title name")]
        public string Authorname { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DataValidation(ErrorMessage = "Title Release date should be less than current date")]
        public DateTime Releasedate { get; set; }
        [Required(ErrorMessage = "Please enter rating Between (1 to 5)")]
        [Range(1, 5, ErrorMessage = "Please Enter Rating Beween 1 to 5 ONLY")]
        public string Rating { get; set; }

        [Display(Name = "Category")]
        public int BookCategoryId { get; set; }

        [ForeignKey("BookCategoryId")]
        public virtual BookCategory? BookCategories { get; set; }   
    }
    public class DataValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime todayDate = Convert.ToDateTime(value);
            return todayDate <= DateTime.Now;
        }

    }
}
