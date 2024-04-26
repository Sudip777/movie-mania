using MovieMania.DTOs.Comments;
using MovieMania.Models;

namespace MovieMania.Interfaces.Repositories
{
    public interface ICommentRepository
    {

        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);

        Task<Comment> CreateAsync(Comment commentModel);
       
    }
}
