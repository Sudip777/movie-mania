namespace MovieMania.DTOs.Comments
{
    public class CommentDto
    {
        // Model - navigational property
        // establishing relationship
        public int? Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? MovieId { get; set; }


    }
}
