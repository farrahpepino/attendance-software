using server.Models;
using server.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server.Services{
    public class AuthService{
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthService (IAuthRepository authRepository, IJwtService jwtService){
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginDto?> LoginUser(int userCode){
            var user = await _authRepository.LoginUser(userCode);
            if (user==null){
                return null;
            }

            var token = _jwtService.GenerateToken(userCode);
            return new LoginDto
            {
                User = user,
                Token = token
            };
        }

    
    }
}

        
        
    