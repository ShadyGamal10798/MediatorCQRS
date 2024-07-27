using MediatorCQRS.Helpers.Constants;
using MediatorCQRS.Helpers.DTOS;
using MediatorCQRS.Helpers.DTOS.Station;
using MediatorCQRS.Helpers.DTOS.Views;
using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Interfaces;
using MediatorCQRS.Helpers.Models;

namespace MediatorCQRS.Services
{
    public class StationService : IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Helpers.DTOS.IResult> AddStaion(Helpers.Models.AddStationRequest model)
        {
            var stationRepo = _unitOfWork.GetRepository<Station>();
            var stationProductRepo = _unitOfWork.GetRepository<StationProduct>();
            var productRepo = _unitOfWork.GetRepository<LKProduct>();
            var tankRepo = _unitOfWork.GetRepository<Tank>();
            var pumpRepo = _unitOfWork.GetRepository<Pump>();
            var posRepo = _unitOfWork.GetRepository<PointOfSale>();

            // Check if StationCode Not Repeated
            var codeExist = await stationRepo.CheckAnyAsync(x => x.Code == model.StationCode);
            if (codeExist) return Result.Failure(MessagesAr.StationCodeIsExist);

            // Check if ERDStationCode Not Repeated
            var erdCodeExist = await stationRepo.CheckAnyAsync(x => x.Code == model.StationERPCode);
            if (erdCodeExist)
                return Result.Failure(MessagesAr.StationERDCodeIsExist);

            var newStation = new Station
            {
                Name = model.StationName,
                CityId = model.CityId,
                RegionId = model.RegionId,
                District = model.District,
                Code = model.StationCode,
                ERPCode = model.StationERPCode,
            };

            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                await stationRepo.CreateAsync(newStation);
                await _unitOfWork.SaveAsync();

                //Add Prices Of The Station
                foreach (var item in model.PricesInfo)
                {
                    //Check If Id Of Product Is Valid (Exist Or Not)
                    var idProductExist = await productRepo.CheckAnyAsync(x => x.Id == item.LKProductId);
                    if (!idProductExist)
                    {
                        _unitOfWork.RollBack();
                        return Result.Failure(MessagesAr.ProductNotFount);
                    }

                    var newStationProduct = new StationProduct
                    {
                        StationId = newStation.Id,
                        LKProductId = item.LKProductId,
                        Price = item.Price
                    };
                    await stationProductRepo.CreateAsync(newStationProduct);
                    await _unitOfWork.SaveAsync();
                }

                foreach (var item in model.TanksInfo)
                {

                    var newTank = new Tank
                    {
                        Code = item.Code,
                        Capacity = item.Capacity,
                        StationId = newStation.Id,
                        LKProductId = item.LKProductId
                    };
                    await tankRepo.CreateAsync(newTank);
                    await _unitOfWork.SaveAsync();
                }

                foreach (var item in model.PumpsInfo)
                {


                    var relatedTank = await tankRepo.GetAsync(x => x.Code == item.TankCode);

                    var newpump = new Pump
                    {
                        Code = item.Code,
                        ERPCode = item.ERPCode,
                        StationId = newStation.Id,
                        TankId = relatedTank.Id
                    };

                    await pumpRepo.CreateAsync(newpump);
                    await _unitOfWork.SaveAsync();
                }

                foreach (var item in model.PosInfo)
                {
                    //Check If IP of POS Is Valid (Exist or Not )
                    var posIsExist = await posRepo.CheckAnyAsync(x => x.Ip == item.PosId || x.AndroidId == item.AndroidId);
                    if (posIsExist)
                    {
                        _unitOfWork.RollBack();
                        return Result.Failure(MessagesAr.IPIsExist);
                    }

                    var newPOS = new PointOfSale
                    {
                        Ip = item.PosId,
                        StationId = newStation.Id,
                        AndroidId = item.AndroidId,
                        LKPointOfSaleId = item.LKPointOfSaleId
                    };
                    await posRepo.CreateAsync(newPOS);
                    await _unitOfWork.SaveAsync();

                }

                transaction.Commit();
                return Result<Station>.Success(MessagesAr.AddStationSuccess, newStation);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Result<Station>.Failure(ex.Message, exception: ex);
            }
        }

        public Task<Helpers.DTOS.IResult> Dashboard(ActiveStationDashboardRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Helpers.DTOS.IResult> District(int? cityId)
        {
            throw new NotImplementedException();
        }

        public Task<Helpers.DTOS.IResult> GetAll(ActiveStationDashboardRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Helpers.DTOS.IResult> StationCodes(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<Helpers.DTOS.IResult> StationDetails(int StationId)
        {
            var mainstationdetailsRepo = _unitOfWork.GetRepository<vw_GetMainStationDetails>();
            var mainstationdetails = await mainstationdetailsRepo.FindAllAsync(x => x.StationId == StationId);

            var stationpricesRepo = _unitOfWork.GetRepository<vw_GetStationPrices>();
            var stationprices = await stationpricesRepo.FindAllAsync(x => x.StationId == StationId);

            var stationTanksRepo = _unitOfWork.GetRepository<vw_GetStationTanks>();
            var stationTanks = await stationTanksRepo.FindAllAsync(x => x.StationId == StationId);

            var stationpumpsRepo = _unitOfWork.GetRepository<vw_GetStationPumps>();
            var stationpumps = await stationpumpsRepo.FindAllAsync(x => x.StationId == StationId);

            var stationpointofsalesRepo = _unitOfWork.GetRepository<vw_GetStationPointOfSales>();
            var stationpointofsales = await stationpointofsalesRepo.FindAllAsync(x => x.StationId == StationId);

            var ans = new StationDetailsDto
            {
                MainStationDetails = mainstationdetails.Count == 0 ? null : mainstationdetails[0],
                StationPrices = stationprices,
                StationTanks = stationTanks,
                StationPumps = stationpumps,
                StationPointOfSales = stationpointofsales,
            };

            return Result<StationDetailsDto>.Success(ans);
        }

        public Task<Helpers.DTOS.IResult> StationOverview(Helpers.Models.StationOverViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Helpers.DTOS.IResult> UpdateStaion(Helpers.Models.UpdateStation model)
        {
            throw new NotImplementedException();
        }
    }
}
