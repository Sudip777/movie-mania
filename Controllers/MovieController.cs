using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMania.Data;
using MovieMania.DTOs.Movie;
using MovieMania.Helpers;
using MovieMania.Mappers;

namespace MovieMania.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MovieController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // ToList has defered execution under the hood
            var movies = await _context.Movie.ToListAsync();
            var moviesDto = movies.Select(s => s.ToMovieDto());
            return Ok(moviesDto);
        }

        // Model Binding under the hood that convert {id} into id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie.ToMovieDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequestDto movieDto)
        {
            var movieModel = movieDto.ToMovieFromCreateDTO();
            await _context.Movie.AddAsync(movieModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = movieModel.Id }, movieModel.ToMovieDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieRequestDto updateDto)

        {
            var movieModel = await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);
            if (movieModel == null)
            {
                return NotFound();
            }
            movieModel.MovieName = updateDto.MovieName;
            movieModel.Rating = updateDto.Rating;
            movieModel.ReleasedDate = updateDto.ReleasedDate;

            await _context.SaveChangesAsync();
            return Ok(movieModel.ToMovieDto());

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var movie = await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

             _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
