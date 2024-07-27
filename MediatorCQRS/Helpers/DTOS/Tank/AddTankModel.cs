namespace MediatorCQRS.Helpers.DTOS.Tank
{
    public record AddTankModel
    (
        int StationId, string Code, decimal Capacity, int LKProductId
    );
}
