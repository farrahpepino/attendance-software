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

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }
    }


}