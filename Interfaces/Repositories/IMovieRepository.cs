using MovieMania.DTOs.Movie;
using MovieMania.Models;

namespace MovieMania.Interfaces.Repositories
{
    public interface IMovieRepository
    {

        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id); // FirstOrDefault can be null so ?

        Task<Movie> CreateAsync(Movie movieModel);
        Task<Movie> UpdateAsync(int id, UpdateMovieRequestDto movieDto);
        Task<Movie> DeleteAsync(int id);

    }
}
