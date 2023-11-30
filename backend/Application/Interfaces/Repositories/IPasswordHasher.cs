namespace Application.Interfaces.Repositories;

public interface IPasswordHasher
{
    string Hash(string passwordPlain);
    bool Verify(string passwordHash, string passwordPlain);
}