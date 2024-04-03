using ExercisingPlanAPI.Data;
using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
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
            return await _context.Users.ToListAsync();
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
