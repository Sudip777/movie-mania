using MovieMania.Models;

namespace MovieMania.DTOs.Movie
{
    public class CreateMovieRequestDto
    {
        public string MovieName { get; set; } = string.Empty;
        public float Rating { get; set; }
        public DateTime ReleasedDate { get; set; }

    }
}
