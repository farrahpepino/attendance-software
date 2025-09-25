using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ScheduleController : ControllerBase{
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService){
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedules(){
            var schedules = await _scheduleService.GetAllSchedules();
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateSchedule([FromBody] Schedule schedule){
            var created = await _scheduleService.CreateSchedule(schedule);
            return CreatedAtAction(nameof(GetAllSchedules), new { id = created.Id }, created);
        }
    }
}
