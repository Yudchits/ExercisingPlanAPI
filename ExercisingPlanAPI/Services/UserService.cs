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

        public async Task<ICollection<User>> GetUserPupilsAsync(User user)
        {
            return await _repository.GetUserPupilsAsync(user);
        }

        public async Task<ICollection<Role>> GetUserRolesAsync(User user)
        {
            return await _repository.GetUserRolesAsync(user);
        }

        public async Task<ICollection<User>> GetUserSubscribersAsync(User user)
        {
            return await _repository.GetUserSubscribersAsync(user);
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
        public async Task<bool> IsUserExistedAsync(User user)
        {
            return await _repository.IsUserExistedAsync(user);
        }
    }
}
