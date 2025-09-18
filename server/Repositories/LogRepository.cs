using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories{
    public class LogRepository: ILogRepository{
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<Log>> GetAllLogs(){
        return await _context.Logs.ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetAllLogsById(string userId){
        return await _context.Logs
                .Where(l => l.UserId == userId)                             
                .ToListAsync();
        }
    }
}