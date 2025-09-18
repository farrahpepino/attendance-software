using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories{

    public class ScheduleRepository: IScheduleRepository{
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context){
            _context = context;
        }


    }

}