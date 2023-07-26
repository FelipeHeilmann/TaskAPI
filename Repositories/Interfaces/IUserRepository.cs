using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(Guid userId);
        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, Guid userId);
        Task<bool> DeleteUser(Guid userId);
    }
}