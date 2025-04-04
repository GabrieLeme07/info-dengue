using FioTec.Service.Domain.Users.Entities;
using FioTec.Service.Domain.Users.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class UserRepository(AppDbContext context) : RepositoryBase<User>(context), IUserRepository
{
    public async Task<User> GetByCPFAsync(string cpf)
        => await _context.Users.FirstOrDefaultAsync(u => u.CPF == cpf);

}
