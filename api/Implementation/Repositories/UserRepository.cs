using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Interface.IRepositories;
using Api.Application;
using Microsoft.EntityFrameworkCore;

namespace api.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _Context;
        public UserRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        public async Task<bool> CheckUserName(string username)
        {
            var checkUserName = await _Context.Users.FindAsync(username);
            return true;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var getAll = await _Context.Users.ToListAsync();
            return getAll;
        }

        public async Task<User> GetUser(string username)
        {
            var checkUserName = await _Context.Users.FindAsync(username);
            return checkUserName;
        }

        public async Task<User> ResgisterUser(User user)
        {
           var create = await _Context.AddAsync(user);
           await _Context.SaveChangesAsync();
           return user;
        }

        public User Update(User user)
        {
           var update = _Context.Update(user);
           _Context.SaveChanges();
           return user;
        }
    }
}