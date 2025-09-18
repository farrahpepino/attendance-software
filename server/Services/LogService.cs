using server.Models;
using server.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server.Services{
    public class LogService{
        private readonly ILogRepository _logRepository;

        public LogService (ILogRepository logRepository){
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<Log>> GetAllLogs(){
            return await _logRepository.GetAllLogs();
        }

        public async Task<IEnumerable<Log>> GetAllLogsByUserId(string userId){
            return await _logRepository.GetAllLogsByUserId(userId);
        }
    }
    
}
