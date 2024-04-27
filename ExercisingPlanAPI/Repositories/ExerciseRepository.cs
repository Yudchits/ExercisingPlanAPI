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
            return await _context.Exercises.Include(entity => entity.TargetMuscleGroup).AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<bool> InsertExerciseAsync(Exercise exercise)
        {
            var targetMuscleGroup = await _context.TargetMuscleGroups.FirstOrDefaultAsync(entity => entity.Id == exercise.TargetMuscleGroupId);

            if (targetMuscleGroup != null)
            {
                exercise.TargetMuscleGroup = targetMuscleGroup;
            }

            await _context.Exercises.AddAsync(exercise);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateExerciseAsync(Exercise exercise)
        {
            var targetMuscleGroup = await _context.TargetMuscleGroups.FindAsync(exercise.TargetMuscleGroupId);

            if (targetMuscleGroup != null)
            {
                exercise.TargetMuscleGroup = targetMuscleGroup;
            }

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

        public async Task<bool> ExerciseNameExistsAsync(string name)
        {
            return await _context.Exercises.AnyAsync(exercise => exercise.Name.Equals(name));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
