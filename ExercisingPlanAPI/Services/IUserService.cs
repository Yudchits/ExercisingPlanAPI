using ExercisingPlanAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByLastNameAsync(string lastName);
        Task<ICollection<User>> GetUserSubscribersAsync(User user);
        Task<ICollection<Role>> GetUserRolesAsync(User user);
        Task<ICollection<User>> GetUserPupilsAsync(User user);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<bool> IsUserExistedAsync(int id);
    }
}
