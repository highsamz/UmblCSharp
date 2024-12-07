using Umbl.Models;

namespace Umbl.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}
