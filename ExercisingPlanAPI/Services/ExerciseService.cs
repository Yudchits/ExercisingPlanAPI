using AutoMapper;
using ExercisingPlanAPI.DTOs;
using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _repository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ExerciseBriefDto>> GetAllExercisesAsync()
        {
            return await _repository.GetAllExercisesAsync().ContinueWith(result => _mapper.Map<ICollection<ExerciseBriefDto>>(result.Result));
        }

        public async Task<ExerciseFullDto> GetExerciseByIdAsync(int id)
        {
            return await _repository.GetExerciseByIdAsync(id).ContinueWith(result => _mapper.Map<ExerciseFullDto>(result.Result));
        }

        public async Task<bool> InsertExerciseAsync(ExerciseFullDto exerciseFull)
        {
            var exerciseMap = _mapper.Map<Exercise>(exerciseFull);
            return await _repository.InsertExerciseAsync(exerciseMap);
        }

        public async Task<bool> UpdateExerciseAsync(ExerciseFullDto exerciseFull)
        {
            var exerciseMap = _mapper.Map<Exercise>(exerciseFull);
            return await _repository.UpdateExerciseAsync(exerciseMap);
        }

        public async Task<bool> DeleteExerciseByIdAsync(int id)
        {
            return await _repository.DeleteExerciseByIdAsync(id);
        }

        public async Task<bool> ExerciseIdExistsAsync(int id)
        {
            return await _repository.ExerciseIdExistsAsync(id);
        }
    }
}
