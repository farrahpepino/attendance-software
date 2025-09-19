using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class AuthController : ControllerBase{
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginUser(int userCode){
            var result = await _authService.LoginUser(userCode);
            if (result==null){
                return NotFound();
            }
            return Ok(result);
        }

       
    }
}