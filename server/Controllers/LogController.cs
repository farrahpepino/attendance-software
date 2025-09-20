using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers{
    [ApiController]
    [Route("[controller]")] 
    public class LogController : ControllerBase{
        private readonly LogService _logService;
        public LogController(LogService logService){
            _logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetAllLogs(){
            var logs = await _logService.GetAllLogs();
            return Ok(logs);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Log>>> GetAllLogsByUserId(string userId){
            var logs = await _logService.GetAllLogsByUserId(userId);
            return Ok(logs);
        }
    }
}