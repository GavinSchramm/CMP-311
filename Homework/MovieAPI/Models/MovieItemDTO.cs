namespace MovieApi.Models;

public class MovieItemDTO
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Year { get; set; }
    public string? Rating { get; set; }
}