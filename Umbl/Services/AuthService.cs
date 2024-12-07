using Umbl.Models;

namespace Umbl.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 4, Username = "pedroP", Password = "xpto", Role = "operador" },
                    new UserModel { UserId = 5, Username = "pedroM", Password = "pass123", Role = "analista" },
                    new UserModel { UserId = 6, Username = "samuel", Password = "admin", Role = "gerente" },
                    new UserModel { UserId = 7, Username = "vinicius", Password = "senha123", Role = "gerente" }
                };


        public UserModel Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
