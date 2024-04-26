using ExercisingPlanAPI.Data;
using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(exercise => exercise.Id == id);
        }

        public async Task<bool> InsertExerciseAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteExerciseByIdAsync(int id)
        {
            var exercise = await GetExerciseByIdAsync(id);
            _context.Exercises.Remove(exercise);
            return await SaveChangesAsync();
        }

        public async Task<bool> ExerciseIdExistsAsync(int id)
        {
            return await _context.Exercises.AnyAsync(exercise => exercise.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
