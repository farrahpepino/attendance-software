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

        var logs = await (
                    from l in _context.Logs
                    where l.Status == "present"
                    join u in _context.Users on l.UserId equals u.Id
                    group l by new { l.UserId, Date = l.CreatedAt.Date, u.Name } into g
                    let latestLog = g.OrderByDescending(l => l.CreatedAt).First()
                    select new LogDto
                    {
                        Id = latestLog.Id,
                        UserId = latestLog.UserId,
                        Name = g.Key.Name,
                        Status = latestLog.Status,
                        CreatedAt = latestLog.CreatedAt
                    }).ToListAsync();

        return logs;
        }

        public async Task<IEnumerable<Log>> GetAllLogsByUserId(string userId){
        
        var logs = await (
                    from l in _context.Logs
                    where l.UserId == userId
                    select l
                    ).ToListAsync();
        return logs;
        }
    }
}