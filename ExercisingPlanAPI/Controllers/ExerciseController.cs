using ExercisingPlanAPI.DTOs;
using ExercisingPlanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private const string SQL_ERROR = "Something went wrong during {0} exercises";
        private const string NO_EXERCISE_ERROR = "There's no exercise with such id";
        private const string ALREADY_EXISTS_ERROR = "Exercise already exists";

        private readonly IExerciseService _service;

        public ExerciseController(IExerciseService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAllExercises")]
        [ProducesResponseType(200, Type = typeof(ICollection<ExerciseBriefDto>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllExercisesAsync()
        {
            var exercises = await _service.GetAllExercisesAsync();
        
            if (exercises == null)
            {
                var message = string.Format(SQL_ERROR, "getting");
                ModelState.AddModelError("SqlError", message);
                return StatusCode(500, ModelState);
            }

            return Ok(exercises);
        }

        [HttpGet]
        [Route("getExerciseById")]
        [ProducesResponseType(200, Type = typeof(ExerciseFullDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetExerciseByIdAsync([FromQuery] int id)
        {
            var exerciseIdExists = await _service.ExerciseIdExistsAsync(id);

            if (!exerciseIdExists)
            {
                ModelState.AddModelError("BodyError", NO_EXERCISE_ERROR);
                return BadRequest(ModelState);
            }

            var exercise = await _service.GetExerciseByIdAsync(id);

            if (exercise == null)
            {
                var message = string.Format(SQL_ERROR, "getting");
                ModelState.AddModelError("SqlError", message);
                return StatusCode(500, ModelState);
            }

            return Ok(exercise);
        }

        // TODO: add targetMuscleGroupService afterwards add getting the targetMuscleGroup by id here
        [HttpPost]
        [Route("insertExercise")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> InsertExerciseAsync([FromBody] ExerciseFullDto exerciseFull)
        {
            var exerciseNameExists = await _service.ExerciseNameExistsAsync(exerciseFull.Name);

            if (exerciseNameExists)
            {
                ModelState.AddModelError("BodyError", ALREADY_EXISTS_ERROR);
                return StatusCode(500, ModelState);
            }

            var isInserted = await _service.InsertExerciseAsync(exerciseFull);

            if (!isInserted)
            {
                var message = string.Format(SQL_ERROR, "inserting");
                ModelState.AddModelError("SqlError", message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut]
        [Route("updateExercise")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateExerciseAsync([FromBody] ExerciseFullDto exerciseFull)
        {
            var exerciseIdExists = await _service.ExerciseIdExistsAsync(exerciseFull.Id);

            if (!exerciseIdExists)
            {
                ModelState.AddModelError("BodyError", NO_EXERCISE_ERROR);
                return BadRequest(ModelState);
            }

            var exercise = await _service.GetExerciseByIdAsync(exerciseFull.Id);

            if (exercise == null)
            {
                var message = string.Format(SQL_ERROR, "getting");
                ModelState.AddModelError("SqlError", message);
                return StatusCode(500, ModelState);
            }

            if (!exerciseFull.Name.Equals(exercise.Name))
            {
                var exerciseNameExists = await _service.ExerciseNameExistsAsync(exerciseFull.Name);

                if (exerciseNameExists)
                {
                    ModelState.AddModelError("BodyError", ALREADY_EXISTS_ERROR);
                    return StatusCode(500, ModelState);
                }
            }

            var isUpdated = await _service.UpdateExerciseAsync(exerciseFull);

            if (!isUpdated)
            {
                var message = string.Format(SQL_ERROR, "updating");
                ModelState.AddModelError("SqlError", message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteExerciseById")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteExerciseByIdAsync([FromBody] int id)
        {
            var exerciseIdExists = await _service.ExerciseIdExistsAsync(id);

            if (!exerciseIdExists)
            {
                ModelState.AddModelError("BodyError", NO_EXERCISE_ERROR);
                return BadRequest(ModelState);
            }

            var isDeleted = await _service.DeleteExerciseByIdAsync(id);

            if (!isDeleted)
            {
                var message = string.Format(SQL_ERROR, "deleting");
                ModelState.AddModelError("SqlError", message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
