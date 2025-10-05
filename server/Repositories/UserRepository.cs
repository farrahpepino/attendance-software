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

        public async Task<IEnumerable<User>> GetAllUsers(){
            var users = await _context.Users
                        .Where(user => user.Role == "user")
                        .ToListAsync();
            return users;
        }

        public async Task UpdateStatus(string id, string status){
            var user = await (
                from u in _context.Users
                where u.Id == id
                select u
                ).FirstOrDefaultAsync();

            if (user != null)
            {
                user.Status = status;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string id){
            var user = await (
                from u in _context.Users
                where u.Id == id
                select u
                ).FirstOrDefaultAsync();

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
