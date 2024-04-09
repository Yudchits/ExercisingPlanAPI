using ExercisingPlanAPI.Data;
using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public class ExercisingPlanRepository : IExercisingPlanRepository
    {
        private readonly DataContext _context;

        public ExercisingPlanRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateExercisingPlanAsync(ExercisingPlan plan)
        {
            await _context.ExercisingPlans.AddAsync(plan);
            var isCreated = await SaveChangesAsync();
            return isCreated;
        }

        public async Task<bool> DeleteAccessToExercisingPlanAsync(UserExercisingPlan userPlans)
        {
            _context.UserExercisingPlans.Remove(userPlans);
            var isDeleted = await SaveChangesAsync();
            return isDeleted;
        }

        public async Task<bool> DeleteExercisingPlanAsync(ExercisingPlan plan)
        {
            _context.ExercisingPlans.Remove(plan);
            var isDeleted = await SaveChangesAsync();
            return isDeleted;
        }

        public async Task<bool> ExercisingPlanExistsAsync(int id)
        {
            return await _context.ExercisingPlans.AnyAsync(ep => ep.Id == id);
        }

        public async Task<ICollection<ExercisingPlan>> GetAllExercisingPlansAsync()
        {
            return await _context.ExercisingPlans.ToListAsync();
        }

        public async Task<ICollection<ExercisingPlan>> GetAvailableExercisingPlansAsync(int userId)
        {
            return await _context.UserExercisingPlans
                .Where(uep => uep.UserId == userId)
                .Select(uep => uep.ExercisingPlan)
                .ToListAsync(); 
        }

        public async Task<ExercisingPlan> GetExercisingPlanByIdAsync(int id)
        {
            return await _context.ExercisingPlans.Include(ep => ep.Owner)
                .Include(ep => ep.WeekPlans).ThenInclude(wp => wp.WeekNumber)
                .Include(ep => ep.WeekPlans).ThenInclude(wp => wp.Weekday)
                .Include(ep => ep.WeekPlans)
                    .ThenInclude(wp => wp.Exercise)
                    .ThenInclude(e => e.TargetMuscleGroup)
                .FirstOrDefaultAsync(ep => ep.Id == id);
        }

        public async Task<ICollection<ExercisingPlan>> GetExercisingPlansOfOwnerAsync(int ownerId)
        {
            return await _context.ExercisingPlans
                .Where(ep => ep.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<bool> MakeExercisingPlanAvailableForUserAsync(UserExercisingPlan userPlans)
        {
            await _context.UserExercisingPlans.AddAsync(userPlans);
            var isSaved = await SaveChangesAsync();
            return isSaved;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateExercisingPlanAsync(ExercisingPlan plan)
        {
            _context.ExercisingPlans.Update(plan);
            var isUpdated = await SaveChangesAsync();
            return isUpdated;
        }
    }
}
