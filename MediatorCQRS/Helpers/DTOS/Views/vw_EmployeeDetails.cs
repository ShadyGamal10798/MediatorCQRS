namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_EmployeeDetails
    {
        //public int StationId { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string EmployeeNumber { get; set; }
        public string PhoneNumber { get; set; }
        //public string StationName { get; set; }
        //public string CityName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
    }
}
