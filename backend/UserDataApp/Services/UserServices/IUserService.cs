using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserDataApp.Models;

namespace UserDataApp.Services.UserServices
{
    public interface IUserService : IDisposable
    {
        Task<List<UserViewModel>> GetAll(int page, int qty);

        Task<User> Get(Guid id);

        Task<UserViewModel> Add(UserInputModel userEntity);

        Task Update(Guid id, UserInputModel userEntity);
        Task Delete(Guid id);

    }
}