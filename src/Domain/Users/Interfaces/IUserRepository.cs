using FioTec.Service.Domain.Users.Entities;

namespace FioTec.Service.Domain.Users.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> GetByCPFAsync(string cpf);
    Task<User> AddAsync(User user);
}
