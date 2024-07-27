using MediatR;

namespace MediatorCQRS.Queries
{
    public class ReadStationDetailsQuery : IRequest<Helpers.DTOS.IResult>
    {
        public int StationId { get; set; }
    }
}
