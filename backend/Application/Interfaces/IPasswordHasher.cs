using Domain;

namespace Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string passwordPlain);
    bool Verify(string passwordHash, string passwordPlain);
}