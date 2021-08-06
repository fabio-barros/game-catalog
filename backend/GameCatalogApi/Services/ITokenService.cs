using UserDataApp.Models;

namespace GameCatalogApi.Services
{
    public interface ITokenService
    {
        public string Generatetoken(User user);
    }
}