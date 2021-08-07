using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserDataApp.Models;

namespace UserDataApp.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();

        Task<User> Get(Guid id);

        Task<User> Add(User userEntity);

        Task Update(Guid id, User userEntity);
        Task Delete(Guid id);

    }
}