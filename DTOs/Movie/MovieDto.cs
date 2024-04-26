using MovieMania.DTOs.Comments;
using MovieMania.Models;

namespace MovieMania.DTOs.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public float Rating { get; set; }
        public DateTime ReleasedDate { get; set; }

        // To add comments in Movie
        public  List<CommentDto>? Comments { get; set; }

    }
}
