using MediatorCQRS.Helpers.DTOS;
using MediatorCQRS.Helpers.Models;

namespace MediatorCQRS.Helpers.Interfaces
{
    public interface IStationService
    {
        Task<DTOS.IResult> GetAll(ActiveStationDashboardRequestModel model);
        Task<DTOS.IResult> StationDetails(int StationId);
        Task<DTOS.IResult> District(int? cityId);
        Task<DTOS.IResult> StationCodes(string code);
        Task<DTOS.IResult> Dashboard(ActiveStationDashboardRequestModel model);
        Task<DTOS.IResult> StationOverview(StationOverViewModel model);
        Task<Helpers.DTOS.IResult> AddStaion(Helpers.Models.AddStationRequest model);
        Task<DTOS.IResult> UpdateStaion(UpdateStation model);
    }

}
