namespace MovieApi.Models;

public class MovieItem
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Year { get; set; }
    public string? Rating { get; set; }
    public string? Secret { get; set; }
}