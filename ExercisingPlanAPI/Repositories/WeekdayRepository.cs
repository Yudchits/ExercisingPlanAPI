using ExercisingPlanAPI.Data;
using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public class WeekdayRepository : IWeekdayRepository
    {
        private readonly DataContext _context;

        public WeekdayRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Weekday>> GetAllWeekdaysAsync()
        {
            return await _context.Weekdays.ToListAsync();
        }

        public async Task<Weekday> GetWeekdayByIdAsync(int id)
        {
            return await _context.Weekdays.FirstOrDefaultAsync(weekday => weekday.Id == id);
        }

        public async Task<bool> InsertWeekdayAsync(Weekday weekday)
        {
            await _context.Weekdays.AddAsync(weekday);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateWeekdayAsync(Weekday weekday)
        {
            _context.Weekdays.Update(weekday);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteWeekdayByIdAsync(int id)
        {
            var weekday = await GetWeekdayByIdAsync(id);
            _context.Remove(weekday);
            return await SaveChangesAsync();
        }

        public async Task<bool> WeekdayIdExists(int id)
        {
            return await _context.Weekdays.AnyAsync(weekday => weekday.Id == id);
        }

        public async Task<bool> WeekdayNameExists(string name)
        {
            return await _context.Weekdays.AnyAsync(weekday => weekday.Name.Equals(name));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
