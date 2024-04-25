namespace MovieMania.DTOs.Movie
{
    public class UpdateMovieRequestDto
    {
        public string MovieName { get; set; } = string.Empty;
        public float Rating { get; set; }
        public DateTime ReleasedDate { get; set; }

    }
}
