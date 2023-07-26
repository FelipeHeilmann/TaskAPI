using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDbContext _dbContext;
        public UserRepository(TaskDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> GetUserById(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, Guid userId)
        {
            UserModel userAlreadyExists = await GetUserById(userId) ?? throw new Exception("User not found");

            userAlreadyExists.Name = user.Name;
            userAlreadyExists.Email = user.Email;
            userAlreadyExists.Role = user.Role;

            _dbContext.Update(userAlreadyExists);
            await _dbContext.SaveChangesAsync();

            return userAlreadyExists;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            UserModel userAlreadyExists = await GetUserById(userId) ?? throw new Exception("User not found");

            _dbContext.Remove(userAlreadyExists);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}