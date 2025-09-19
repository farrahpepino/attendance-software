using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Repositories {

    public class ScheduleRepository: IScheduleRepository{
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context){
            _context = context;
        }

          public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }

    public async Task<Schedule> CreateSchedule(Schedule schedule){
        var random = new Random();
        int code;
        bool exists;

        do
        {
            code = random.Next(10000000, 100000000);
            exists = await _context.Schedules.AnyAsync(s => s.UserCode == code);
        } while (exists);

        schedule.UserCode = code;

        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        return schedule;
    }
    }
}