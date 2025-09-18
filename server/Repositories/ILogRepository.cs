using server.Models;

namespace server.Repositories{
    public interface ILogRepository{
        Task<IEnumerable<Log>> GetAllLogs();
        Task<IEnumerable<Log>> GetAllLogsById(string userId);
    }
}