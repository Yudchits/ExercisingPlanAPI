using ExercisingPlanAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByLastNameAsync(string lastName);
        Task<ICollection<User>> GetUserSubscribersAsync(int id);
        Task<ICollection<Role>> GetUserRolesAsync(int id);
        Task<ICollection<User>> GetUserPupilsAsync(int id);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<bool> UserExistsAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
