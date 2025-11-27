using Microsoft.AspNetCore.Mvc;
using TestTask.App.DTOs;
using TestTask.App.Interfaces;

namespace TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carsService)
        {
            _carService = carsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarDto carsDto)
        {
            try
            {
                if (carsDto == null)
                {
                    return BadRequest("Balance cannot be null.");
                }

                await _carService.AddCarAsync(carsDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{guid}", Name = "GetCarById")]
        public async Task<IActionResult> GetCarById([FromRoute] Guid guid)
        {
            try
            {
                var response = await _carService.GetCarAsync(guid);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllCars", Name = "GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            var response = await _carService.GetAsync();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, [FromBody] CarDto car)
        {
            try
            {
                await _carService.UpdateCarAsync(id, car);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar([FromQuery] Guid guid)
        {
            try
            {
                await _carService.RemoveCarAsync(guid);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}