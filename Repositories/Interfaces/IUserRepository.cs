using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById();
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, string userId);
        Task<bool> DeleteUser(string userId);
    }
}