using AutoMapper;
using MediatorCQRS.Helpers.DTOS;
using MediatorCQRS.Helpers.DTOS.LKs;
using MediatorCQRS.Helpers.DTOS.Reports;
using MediatorCQRS.Helpers.DTOS.Station;
using MediatorCQRS.Helpers.DTOS.Views;
using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.ClientAggregateRoot;
using MediatorCQRS.Helpers.Enums;

namespace MediatorCQRS.Helpers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, GetProfileDto>();
            CreateMap<ApplicationUser, UpdateEmployeeDetailsResponse>();
            //CreateMap<StationProduct, GetProductsDto>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LKProduct.ArName));
            CreateMap<StationProduct, GetProductsDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LKProduct.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest, destMember, context) =>
        {
            // Assume context.Options.Items["Language"] holds the language preference
            string language = (string)context.Items["lng"];
            return language switch
            {
                "ar" => src.LKProduct.ArName,
                "en" => src.LKProduct.EnName,
                "ur" => src.LKProduct.UrName,
                "bn" => src.LKProduct.BnName,
                _ => src.LKProduct.ArName // Default to arabic if language is not recognized
            };
        }));
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<LKOrderType, GetOrderTypesDto>();
            CreateMap<SendOrderDetailsDto, Order>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Math.Round(src.Price, 2)))
            .ForMember(dest => dest.Liters, opt => opt.MapFrom(src => Math.Round(src.Liters, 2)));


            CreateMap<EscapeDto, Escape>();



            CreateMap<LKCity, LKCityDto>().ReverseMap();
            CreateMap<LKRegion, LKRegionDto>().ReverseMap();
            CreateMap<Station, StationDto>().ReverseMap();
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Address) ? src.FullAddress : src.Address))
                .ReverseMap();

            CreateMap<UpdateStation, Station>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StationId))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StationName))
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.StationCode))
             .ForMember(dest => dest.ERPCode, opt => opt.MapFrom(src => src.StationERPCode))
             .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
             .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
             .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District));





            CreateMap<LKProduct, LKProductDto>().ReverseMap();
            CreateMap<LKPointOfSale, LKPointOfSaleDto>().ReverseMap();
            CreateMap<Customer, CustomerDetailsDto>().ReverseMap();

            CreateMap<Order, GetZatcaReportsDto>()
               .ForMember(dest => dest.StationName, opt => opt.MapFrom(src => src.Station.Name))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.LKProduct.ArName))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Station.LKCity.ArName))
            .ForMember(dest => dest.WorkerNumber, opt => opt.MapFrom(src => src.ApplicationUser.EmployeeNumber))
            .ForMember(dest => dest.InvoiceType, opt => opt.MapFrom(src => src.IsActive ? src.LKInvoiceType.NameAr : "فاتورة مكررة"))
            .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.LKOrderType.Id == (int)OrderType.Cash ? "كاش" : "شبكة"))
            .ForMember(dest => dest.CreditOrDebitOrderSerial, opt => opt.MapFrom(src => src.CreditOrDebitMainOrder.OrderSerial))
            .ForMember(dest => dest.ZatcaStatus, opt => opt.MapFrom(src => src.ZatcaStatus ? "تم الربط" : "فشل الربط"))
            .ForMember(dest => dest.CreditOrDebitStatus, opt => opt.MapFrom(src => src.CreditOrDebitMainOrder == null ? false : true))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Math.Round(src.Price, 2)))
             .ForMember(dest => dest.Liters, opt => opt.MapFrom(src => Math.Round(src.Liters, 1)))
            ;

            CreateMap<GeneralBudgetReportView, GetDailyReportDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    // Assume context.Options.Items["Language"] holds the language preference
                    string language = (string)context.Items["lng"];
                    return language switch
                    {
                        "ar" => src.ProductNameAr,
                        "en" => src.ProductNameEn,
                        "ur" => src.ProductNameUr,
                        "bn" => src.ProductNameBn,
                        _ => src.ProductNameAr // Default to arabic if language is not recognized
                    };
                }));


        }
    }
}
