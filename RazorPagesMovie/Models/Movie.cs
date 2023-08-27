using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    //An ID field to provide a primary key for the database.
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Title { get; set; } = string.Empty;

    /**
*A [DataType] attribute to specify the type of data in the ReleaseDate field. With this attribute:
*The user is not required to enter time information in the date field.
*Only the date is displayed, not time information.
**/
    [DataType(DataType.Date)]
    //The [Display] attribute specifies the display name of a field. In the preceding code, Release Date instead of ReleaseDate.
    [Display(Name ="Release Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }

     [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string Genre { get; set; } = string.Empty;

//The [Column(TypeName = "decimal(18, 2)")] data annotation enables Entity Framework Core to correctly map Price to currency in the database. 
    [Column(TypeName = "decimal(18, 2)")]
     [Range(1, 100)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rate { get; set; } = string.Empty;
}