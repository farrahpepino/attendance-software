using server.Models;

namespace server.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> LoginUser(int userCode);
    }
}
