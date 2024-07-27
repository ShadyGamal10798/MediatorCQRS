namespace MediatorCQRS.Helpers.DTOS
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInDays { get; set; }
        public double DurationInHours { get; set; }
        public double DurationInMinutes { get; set; }
    }

    public class OTPSettings
    {
        public int ExpirationMinutes { get; set; }
    }
}
