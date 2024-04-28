using MovieMania.Models;

namespace MovieMania.Interfaces.Service
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}
