using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class AuthRepository : IAuthRepository{
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context){
            _context = context;
        }

        public async Task<User?> LoginUser(int userCode){
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserCode == userCode); //might cause the app to crash
            return user;
        }

    }
}
