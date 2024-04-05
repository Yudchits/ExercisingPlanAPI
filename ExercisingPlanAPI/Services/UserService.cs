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

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByLastNameAsync(string lastName)
        {
            return await _repository.GetUserByLastNameAsync(lastName);
        }

        public async Task<ICollection<User>> GetUserPupilsAsync(int id)
        {
            return await _repository.GetUserPupilsAsync(id);
        }

        public async Task<ICollection<Role>> GetUserRolesAsync(int id)
        {
            return await _repository.GetUserRolesAsync(id);
        }

        public async Task<ICollection<User>> GetUserSubscribersAsync(int id)
        {
            return await _repository.GetUserSubscribersAsync(id);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            return await _repository.CreateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            return await _repository.DeleteUserAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _repository.UpdateUserAsync(user);
        }
        public async Task<bool> IsUserExistedAsync(int id)
        {
            return await _repository.IsUserExistedAsync(id);
        }
    }
}
