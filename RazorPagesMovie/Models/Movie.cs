using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    //An ID field to provide a primary key for the database.
    public int Id { get; set; }

    //The question mark (?) after string indicates that the property is nullable. 
    public string? Title { get; set; }

    /**
*A [DataType] attribute to specify the type of data in the ReleaseDate field. With this attribute:
*The user is not required to enter time information in the date field.
*Only the date is displayed, not time information.
**/
    [DataType(DataType.Date)]
    //The [Display] attribute specifies the display name of a field. In the preceding code, Release Date instead of ReleaseDate.
    [Display(Name ="Release Date")]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }

//The [Column(TypeName = "decimal(18, 2)")] data annotation enables Entity Framework Core to correctly map Price to currency in the database. 
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}