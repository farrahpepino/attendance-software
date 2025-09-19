using server.Models;
using server.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server.Services{
    public class UserService{
        private readonly IUserRepository _userRepository;

        public UserService (IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public async Task<User?> LoginUser(int userCode){
            return await _userRepository.LoginUser(userCode);
        }

        public async Task<IEnumerable<User>> GetAllUsers(){
            return await _userRepository.GetAllUsers();
        }
        
        public async Task UpdateStatus(string id, string status){
            await _userRepository.UpdateStatus(id, status);
        }

        public async Task DeleteUser(string id){
            await _userRepository.DeleteUser(id);
        }
    }
}

        
        
    