using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZwalApp.API.Models;

namespace ZwalApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;
        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task<User> Login(string username, string password)
        {
            var user= await _dataContext.Users.FirstOrDefaultAsync(x=>x.Username==username);
            if(user==null) return null;
            if(!VerifyPasswordHash(password,user.PasswordSalt ,user.PasswordHash ))
            return null;
             return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var Computedhash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < Computedhash.Length; i++)
                {
                    if(Computedhash[i]!=passwordHash[i]) return false;

                }
                return true;
            }
        }

        private bool VerifyPasswordHash(string v, string password, object p1, object a, object p2, object b)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
           byte [] passwordHash,passwordSalt;
           CreatePasswordHash(password,out passwordHash,out passwordSalt);
           user.PasswordHash=passwordHash;
           user.PasswordSalt=passwordSalt;
           await _dataContext.Users.AddAsync(user);
           await _dataContext.SaveChangesAsync();
           return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac= new System.Security.Cryptography.HMACSHA512()){
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }   
        }

        public async Task<bool> UserExistis(string username)
        {
            if(await _dataContext.Users.AnyAsync(x=>x.Username==username)) return true;
            return false;
        }
    }
}