using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CreateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByLastNameAsync(string lastName)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<User>> GetUserPupilsAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Role>> GetUserRolesAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<User>> GetUserSubscribersAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
