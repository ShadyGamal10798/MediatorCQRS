namespace MediatorCQRS.Helpers.DTOS
{
    public record AddPumpModel
    (
        int StationId, string Code, string ERPCode, int TankId
    );
}
