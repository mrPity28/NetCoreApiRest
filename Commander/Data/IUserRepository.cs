using Commander.Dtos;
using Commander.Models;
using System.Collections.Generic;

namespace Comander.Data
{
    public interface IUserRepository
    {
        bool SaveChanges();

        AuthenticateResponseDto Authenticate(AuthenticateRequestDto model);
        IEnumerable<User> GetAll();
        User GetById(int id);

    }
}