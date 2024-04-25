namespace MovieMania.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public float Rating { get; set; }
        public DateTime ReleasedDate { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
