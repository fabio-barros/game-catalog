using System;
using System.Threading.Tasks;
using UserDataApp.Models;

namespace UserDataApp.Services.LoginServices
{
    public interface ILoginService : IDisposable
    {
        Task<UserViewModel> Login(LoginInfo login);

    }
}