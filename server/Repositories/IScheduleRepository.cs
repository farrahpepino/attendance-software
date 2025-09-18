using server.Models;

namespace server.Repositories{
    public interface IScheduleRepository{
        Task<IEnumerable<Schedule>> GetAllSchedules();
        Task<Schedule> CreateSchedule(Schedule schedule);
    }
}