using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
// do while
namespace server.Repositories {

    public class ScheduleRepository: IScheduleRepository{
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context){
            _context = context;
        }

        public async IAsyncEnumerable<Schedule> GetAllSchedules(){
            await foreach(var schedule in _context.Schedules.AsAsyncEnumerable()){
                yield return schedule;
            }
        }

    public async Task<Schedule> CreateSchedule(Schedule schedule){
        var random = new Random();
        int code;
        bool exists;

        do{
            code = random.Next(10000000, 100000000);
            exists = await _context.Schedules.AnyAsync(schedule => schedule.UserCode == code);
        } while (exists);

        schedule.UserCode = code;

        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        return schedule;
    }
    }
}