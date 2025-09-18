using server.Models;

namespace server.Repositories
{
    public interface IUserRepository
    {
        Task<User?> LoginUser(int userCode);
        Task<List<User>> GetAllUsers();
        Task CreateUser (string name);
        Task UpdateStatus(string id, string status);
        Task DeleteUser(string id);
    }
}
