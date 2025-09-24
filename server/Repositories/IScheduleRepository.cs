using server.Models;

namespace server.Repositories{
    public interface IScheduleRepository{
        IAsyncEnumerable<Schedule> GetAllSchedules();
        Task<Schedule> CreateSchedule(Schedule schedule);
    }
}