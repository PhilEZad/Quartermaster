namespace Application.Interfaces.Repositories;

public interface IJwtProvider
{
    public string GenerateToken(string username, string password);
}