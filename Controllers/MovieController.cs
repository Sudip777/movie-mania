using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMania.Data;
using MovieMania.DTOs.Movie;
using MovieMania.Helpers;
using MovieMania.Interfaces.Repositories;
using MovieMania.Mappers;

namespace MovieMania.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMovieRepository _movieRepository;

        public MovieController(ApplicationDBContext context, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _context = context;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            // ToList has defered execution under the hood
            //var movies = await _movieRepository.GetAllAsync(); Before filtering
            var movies = await _movieRepository.GetAllAsync(query);
            var moviesDto = movies.Select(s => s.ToMovieDto());
            return Ok(moviesDto);
        }

        // Model Binding under the hood that convert {id} into id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var movie = await _movieRepository.GetByIdAsync( id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie.ToMovieDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequestDto movieDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var movieModel = movieDto.ToMovieFromCreateDTO();
            await _movieRepository.CreateAsync(movieModel);
            return CreatedAtAction(nameof(GetById), new { id = movieModel.Id }, movieModel.ToMovieDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieRequestDto updateDto)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var movieModel = await _movieRepository.UpdateAsync(id, updateDto);
            if (movieModel == null)
            {
                return NotFound();
            }
            return Ok(movieModel.ToMovieDto());

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = await _movieRepository.DeleteAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
