namespace MediatorCQRS.Helpers.DTOS
{
    public record AddPOSModel
    (
        int StationId, string Ip, string AndroidId, int LKPointOfSaleId
    );
}
