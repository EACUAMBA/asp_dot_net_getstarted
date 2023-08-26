using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovies.Models;

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
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}