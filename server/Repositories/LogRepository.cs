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

        public async Task<IEnumerable<LogDto>> GetAllLogs(){
        return await _context.Logs
                .Where(log => log.Status == "present")
                .GroupBy(log => new {log.UserId, Date = log.CreatedAt.Date, log.User.Name})
                .Select(group => group
                    .OrderByDescending(log => log.CreatedAt)
                    .Select(log => new LogDto{
                        Id = log.Id,
                        UserId = log.UserId,
                        Name = log.User.Name,
                        Status = log.Status,
                        CreatedAt = log.CreatedAt
                    })
                    .First() 
                )
                .ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetAllLogsByUserId(string userId){
        return await _context.Logs
                .Where(log => log.UserId == userId)                             
                .ToListAsync();
        }
    }
}