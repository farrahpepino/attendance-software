using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace server.Repositories
{
    public class UserRepository : IUserRepository{
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context){
            _context = context;
        }

        public async Task<User> LoginUser(int userCode){
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserCode == userCode);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers(){
            var users = await _context.Users
                        .Where(u => u.Role == "user")
                        .ToListAsync();
            return users;
        }

        public async Task UpdateStatus(string id, string status){
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Status = status;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string id){
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
