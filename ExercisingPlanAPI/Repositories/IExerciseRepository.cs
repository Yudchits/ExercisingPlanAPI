using ExercisingPlanAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Repositories
{
    public interface IExerciseRepository
    {
        Task<ICollection<Exercise>> GetAllExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<bool> InsertExerciseAsync(Exercise exercise);
        Task<bool> UpdateExerciseAsync(Exercise exercise);
        Task<bool> DeleteExerciseByIdAsync(int id);
        Task<bool> ExerciseIdExistsAsync(int id);
        Task<bool> ExerciseNameExistsAsync(string name);
        Task<bool> SaveChangesAsync();
    }
}
