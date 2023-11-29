using Domain;

namespace Application.Interfaces;

public interface IAccountService
{
    public Boolean Create(User user);
}