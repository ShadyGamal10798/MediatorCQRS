namespace MediatorCQRS.Helpers.DTOS
{
    public class UpdatePasswordRequest
    {
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OTP { get; set; }
    }
    public class SendOtpRequest
    {
        public string Email { get; set; }
    }
}
