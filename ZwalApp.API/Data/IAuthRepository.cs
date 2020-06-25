using System.Threading.Tasks;
using ZwalApp.API.Models;

namespace ZwalApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user,string password);
         Task<User> Login(string username,string password);
         Task<bool> UserExistis(string username);
    }
}