using ExercisingPlanAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public interface IExerciseService
    {
        Task<ICollection<ExerciseBriefDto>> GetAllExercisesAsync();
        Task<ExerciseFullDto> GetExerciseByIdAsync(int id);
        Task<bool> InsertExerciseAsync(ExerciseFullDto exerciseFull);
        Task<bool> UpdateExerciseAsync(ExerciseFullDto exerciseFull);
        Task<bool> DeleteExerciseByIdAsync(int id);
        Task<bool> ExerciseIdExistsAsync(int id);
    }
}
