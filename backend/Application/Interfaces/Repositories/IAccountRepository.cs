using Domain;

namespace Application.Interfaces;

public interface IAccountRepository
{
    User create(User user);

}