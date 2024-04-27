using MovieMania.DTOs.Comments;
using MovieMania.Models;
using System.Runtime.CompilerServices;

namespace MovieMania.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                MovieId = commentModel.MovieId

            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int movieId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                MovieId = movieId
            };


        }

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
        
            };


        }
    }
}
