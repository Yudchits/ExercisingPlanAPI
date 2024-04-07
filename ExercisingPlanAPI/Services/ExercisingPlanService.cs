using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public class ExercisingPlanService : IExercisingPlanService
    {
        private readonly IExercisingPlanRepository _repository;

        public ExercisingPlanService(IExercisingPlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateExercisingPlanAsync(ExercisingPlan plan)
        {
            return await _repository.CreateExercisingPlanAsync(plan);
        }

        public async Task<bool> DeleteAccessToExercisingPlanAsync(UserExercisingPlan userPlans)
        {
            return await _repository.DeleteAccessToExercisingPlanAsync(userPlans);
        }

        public async Task<bool> DeleteExercisingPlanAsync(ExercisingPlan plan)
        {
            return await _repository.DeleteExercisingPlanAsync(plan);
        }

        public async Task<bool> ExercisingPlanExistsAsync(int id)
        {
            return await _repository.ExercisingPlanExistsAsync(id);
        }

        public async Task<ICollection<ExercisingPlan>> GetAllExercisingPlansAsync()
        {
            return await _repository.GetAllExercisingPlansAsync();
        }

        public async Task<ICollection<ExercisingPlan>> GetAvailableExercisingPlansAsync(int userId)
        {
            return await _repository.GetAvailableExercisingPlansAsync(userId);
        }

        public async Task<ExercisingPlan> GetExercisingPlanByIdAsync(int id)
        {
            return await _repository.GetExercisingPlanByIdAsync(id);
        }

        public async Task<ICollection<ExercisingPlan>> GetExercisingPlansOfOwnerAsync(int ownerId)
        {
            return await _repository.GetExercisingPlansOfOwnerAsync(ownerId);
        }

        public async Task<bool> MakeExercisingPlanAvailableForUserAsync(UserExercisingPlan userPlans)
        {
            return await _repository.MakeExercisingPlanAvailableForUserAsync(userPlans);
        }

        public async Task<bool> UpdateExercisingPlanAsync(ExercisingPlan plan)
        {
            return await _repository.UpdateExercisingPlanAsync(plan);
        }
    }
}
