using MovieMania.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieMania.DTOs.Movie
{
    public class CreateMovieRequestDto
    {
        [Required]
        [MaxLength(20,ErrorMessage ="MovieName cannot be over 20 characters")]
        public string MovieName { get; set; } = string.Empty;
        [Required]
        [Range(0.1, 10)]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Released date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Released Date")]
        [Range(typeof(DateTime), "1900-01-01", "{0:yyyy-MM-dd}", 
            ErrorMessage = "Release date must be between 1900-01-01 and today's date.")]
        public DateTime ReleasedDate { get; set; }

    }
}
