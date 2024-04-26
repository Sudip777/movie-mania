namespace MovieMania.Models
{
    public class Comment
    {
        // establishing relationship
        public int? Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? MovieId { get; set; }

        // Navigation Property
        public Movie? Movie { get; set; }

    }
}
