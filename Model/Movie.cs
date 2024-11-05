using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empty;

[Table(("movie"))]
public class Movie
{
    public Movie()
    {
    }

    public Movie( int id, string? title, DateOnly releaseDate, string? genre, decimal price)
    {
        Id = id;
        Title = title;
        ReleaseDate = releaseDate;
        Genre = genre;
        Price = price;
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]
    public string? Title { get; set; }
    
    [Column("release_date")]
    public DateOnly? ReleaseDate { get; set; }
    
    [Column("update_date")]
    public DateOnly? UpdateDate { get; set; }
    
    [Column("genre")]
    public string? Genre { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }

    public override string ToString()
    {
        return "{\n" + $" Id: {Id},\n Title: {Title},\n ReleaseDate: {ReleaseDate},\n Genre: {Genre},\n Price :{Price}" + "\n}";
    }
}