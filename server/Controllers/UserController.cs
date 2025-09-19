using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// createdAtAction - study

namespace server.Controllers{
    [ApiController]
    [Route("[controller]")] 
    public class UserController : ControllerBase{
        private readonly UserService _userService;

        public UserController(UserService userService){
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(){
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] string status){
            await _userService.UpdateStatus(id, status);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id){
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
