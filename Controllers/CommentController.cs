using Microsoft.AspNetCore.Mvc;
using MovieMania.DTOs.Comments;
using MovieMania.Interfaces.Repositories;
using MovieMania.Mappers;

namespace MovieMania.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMovieRepository _movieRepository;

        public CommentController(ICommentRepository commentRepository, IMovieRepository movieRepository)
        {
            _commentRepository = commentRepository;
            _movieRepository = movieRepository;
            
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }


        [HttpGet]
        [Route("{id}")]
            public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if(comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        [Route("{movieId}")]
        public async Task<IActionResult> Create( [FromRoute] int movieId, CreateCommentDto commentDto )
        {
            if (!await _movieRepository.MovieExists(movieId))
            {
                return BadRequest("Movie does not exist!!");
            }
            var commentModel = commentDto.ToCommentFromCreate(movieId);
            await _commentRepository.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var commentModel = await _commentRepository.DeleteAsync(id);
            

            if(commentModel == null)
            {
                return NotFound("Comment doesn't exist");
            }
            return Ok(commentModel);
        }

    }
}
