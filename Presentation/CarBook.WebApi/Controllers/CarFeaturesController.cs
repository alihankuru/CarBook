using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeatureByCarId")]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);

        }


        //Buradaki Handle tam tersi çalışıyor change to true doğrusu
        [HttpGet("CarFeatureChangeToTrue")]
        public async Task<IActionResult> CarFeatureChangeToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı");
        }

        //Buradaki Handle tam tersi çalışıyor change to false doğrusu
        [HttpGet("CarFeatureChangeToFalse")]
        public async Task<IActionResult> CarFeatureChangeToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı");
        }


        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme İşlemi Yapıldı");
        }

    }
}
