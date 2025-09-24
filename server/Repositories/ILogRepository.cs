using server.Models;

namespace server.Repositories{
    public interface ILogRepository{
        Task<IEnumerable<LogDto>> GetAllLogs();
        Task<IEnumerable<Log>> GetAllLogsByUserId(string userId);
    }
}