using server.Models;
using server.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server.Services{
    public class ScheduleService{
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository){
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules(){
            return await _scheduleRepository.GetAllSchedules();
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule){
            return await _scheduleRepository.CreateSchedule(schedule);
        }
    }
}