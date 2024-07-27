using MediatorCQRS.Helpers.Interfaces;
using MediatorCQRS.Queries;
using MediatR;

namespace MediatorCQRS.Handlers.QueriesHandler
{
    public class ReadStationDetailsQueryHandler : IRequestHandler<ReadStationDetailsQuery, Helpers.DTOS.IResult>
    {
        private readonly IStationService _stationService;
        public ReadStationDetailsQueryHandler(IStationService stationService)
        {
            _stationService = stationService;
        }
        public async Task<Helpers.DTOS.IResult> Handle(ReadStationDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _stationService.StationDetails(request.StationId);



        }
    }
}
