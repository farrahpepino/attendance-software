using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<User>> GetAllUsers(){
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task CreateUser(string name){
            var random = new Random();
            int code;
            bool exists;

            do
            {
                code = random.Next(10000000, 100000000);
                exists = await _context.Users.AnyAsync(u => u.UserCode == code);
            } while (exists);

            var user = new User
            {
                Name = name,
                UserCode = code
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
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
