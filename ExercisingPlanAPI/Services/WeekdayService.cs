using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public class WeekdayService : IWeekdayService
    {
        private readonly IWeekdayRepository _repository;

        public WeekdayService(IWeekdayRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Weekday>> GetAllWeekdaysAsync()
        {
            return await _repository.GetAllWeekdaysAsync();
        }

        public async Task<Weekday> GetWeekdayByIdAsync(int id)
        {
            return await _repository.GetWeekdayByIdAsync(id);
        }

        public async Task<bool> InsertWeekdayAsync(Weekday weekday)
        {
            return await _repository.InsertWeekdayAsync(weekday);
        }

        public async Task<bool> UpdateWeekdayAsync(Weekday weekday)
        {
            return await _repository.UpdateWeekdayAsync(weekday);
        }

        public async Task<bool> DeleteWeekdayByIdAsync(int id)
        {
            return await _repository.DeleteWeekdayByIdAsync(id);
        }
    }
}
