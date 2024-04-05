using ExercisingPlanAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public interface IExercisingPlanRepository
    {
        Task<ICollection<ExercisingPlan>> GetAllExercisingPlansAsync();
        Task<ExercisingPlan> GetExercisingPlanByIdAsync(int id);
        Task<ICollection<ExercisingPlan>> GetExercisingPlansOfOwnerAsync(int ownerId);
        Task<ICollection<ExercisingPlan>> GetAvailableExercisingPlans(int userId);
        Task<bool> MakeExercisingPlanAvailableForUserAsync(UserExercisingPlan userPlans);
        Task<bool> DeleteAccessToExercisingPlanAsync(UserExercisingPlan userPlans);
        Task<bool> CreateExercisingPlanAsync(ExercisingPlan plan);
        Task<bool> UpdateExercisingPlanAsync(ExercisingPlan plan);
        Task<bool> DeleteExercisingPlanAsync(ExercisingPlan plan);
        Task<bool> ExercisingPlanExistsAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
