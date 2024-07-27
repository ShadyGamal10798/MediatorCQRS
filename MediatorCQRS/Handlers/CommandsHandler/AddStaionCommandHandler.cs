using MediatorCQRS.Commands;
using MediatorCQRS.Helpers.DTOS;
using MediatorCQRS.Helpers.Interfaces;
using MediatorCQRS.Helpers.Models;
using MediatR;

namespace MediatorCQRS.Handlers.CommandsHandler
{
    public class AddStaionCommandHandler : IRequestHandler<AddStaionCommand>
    {
        private readonly IStationService _stationService;
        public AddStaionCommandHandler(IStationService stationService)
        {
            _stationService = stationService;
        }
        public async Task Handle(AddStaionCommand request, CancellationToken cancellationToken)
        {
            var addStationModel = new AddStationRequest(
                    request.StationName,
                    request.StationCode,
                    request.StationERPCode,
                    request.CityId,
                    request.RegionId,
                    request.District,
                    request.PricesInfo,
                    request.TanksInfo,
                    request.PumpsInfo,
                    request.PosInfo
                );
            await _stationService.AddStaion(addStationModel);
        }
    }
}
