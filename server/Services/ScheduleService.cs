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

        public async Task<List<Schedule>> GetAllSchedules(){
            var list = new List<Schedule>();
            await foreach (var schedule in _scheduleRepository.GetAllSchedules()){
                list.Add(schedule);
            }
            return list;
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule){
            return await _scheduleRepository.CreateSchedule(schedule);
        }
    }
}