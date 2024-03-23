using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLastFiveCarsWithBrandQueryHandler _getLastFiveCarsWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLastFiveCarsWithBrandQueryHandler getLastFiveCarsWithBrandQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastFiveCarsWithBrandQueryHandler = getLastFiveCarsWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var value = _getCarWithBrandQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("GetLastCarsFiveWithBrand")]
        public IActionResult GetLastCarsFiveWithBrand()
        {
            var value = _getLastFiveCarsWithBrandQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("Car bilgisi eklendi...");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car bilgisi silindi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car bilgisi guncellendi...");
        }
    }


}
