using ExercisingPlanAPI.Data;
using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> GetUserByLastNameAsync(string lastName)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.LastName.ToLower() == lastName.ToLower());
        }

        public async Task<ICollection<User>> GetUserPupilsAsync(int id)
        {
            return await _context.CoachPupils.Where(cp => cp.CoachId == id).Select(cp => cp.Pupil).ToListAsync();
        }

        public async Task<ICollection<Role>> GetUserRolesAsync(int id)
        {
            return await _context.UserRoles.Where(ur => ur.UserId == id).Select(ur => ur.Role).ToListAsync();
        }

        public async Task<ICollection<User>> GetUserSubscribersAsync(int id)
        {
            return await _context.UserSubscribers.Where(us => us.SubscribeToId == id).Select(us => us.Subscriber).ToListAsync();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);

            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);

            return await SaveChangesAsync();
        }
        public async Task<bool> UserExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(entity => entity.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var affectedRows = await _context.SaveChangesAsync();

            return affectedRows > 0;
        }
    }
}
