using MediatorCQRS.Commands;
using MediatorCQRS.Helpers.Models;
using MediatorCQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorCQRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> StationDetails(int StationId)
        {
            var query = new ReadStationDetailsQuery { StationId = StationId };
            var oResult = await _mediator.Send(query);
            return Ok(oResult);
        }
        [HttpPost]
        public async Task AddStaion([FromBody] AddStationRequest model)
        {
            var query = new AddStaionCommand(
                model.StationName,
                model.StationCode,
                model.StationERPCode,
                model.CityId,
                model.RegionId,
                model.District,
                model.PricesInfo,
                model.TanksInfo,
                model.PumpsInfo,
                model.PosInfo
            );
            await _mediator.Send(query);
        }
    }
}
