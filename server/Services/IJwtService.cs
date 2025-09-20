namespace server.Services{
    public interface IJwtService{
        string GenerateToken(int userCode);
    }
}