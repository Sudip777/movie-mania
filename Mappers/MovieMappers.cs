using MovieMania.DTOs.Movie;
using MovieMania.Models;

namespace MovieMania.Mappers
{
    public static class MovieMappers
    {

        public static MovieDto ToMovieDto(this Movie movieModel)
        {
            return new MovieDto
            {
                Id = movieModel.Id,
                MovieName = movieModel.MovieName,
                Rating = movieModel.Rating,
                ReleasedDate = movieModel.ReleasedDate
            };
        }

        public static Movie ToMovieFromCreateDTO(this CreateMovieRequestDto movieDto)
        {
            return new Movie
            {
                MovieName = movieDto.MovieName,
                Rating = movieDto.Rating,
                ReleasedDate = movieDto.ReleasedDate,
            };

        }
    }
}