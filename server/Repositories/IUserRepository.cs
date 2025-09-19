using server.Models;

namespace server.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task UpdateStatus(string id, string status);
        Task DeleteUser(string id);
    }
}
