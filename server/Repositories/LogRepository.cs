using server.Data;
using server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories{
    public class LogRepository: ILogRepository{
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<Log>> GetAllLogs(){
        return await _context.Logs
                .Where(log => log.Status == "present")
                .Include(log => log.User) //only need userid and usernames
                .GroupBy(log => new {log.UserId, Date = log.CreatedAt.Date})
                .Select(group => group.OrderByDescending(log => log.CreatedAt).FirstOrDefault())
                .ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetAllLogsByUserId(string userId){
        return await _context.Logs
                .Where(log => log.UserId == userId)                             
                .ToListAsync();
        }
    }
}