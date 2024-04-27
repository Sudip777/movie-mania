using MovieMania.DTOs.Movie;
using MovieMania.Helpers;
using MovieMania.Models;

namespace MovieMania.Interfaces.Repositories
{
    public interface IMovieRepository
    {

        Task<List<Movie>> GetAllAsync(QueryObject query);
        Task<Movie?> GetByIdAsync(int id); // FirstOrDefault can be null so ?

        Task<Movie> CreateAsync(Movie movieModel);
        Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movieDto);
        Task<Movie?> DeleteAsync(int id);

        Task<bool> MovieExists(int id);

    }
}
