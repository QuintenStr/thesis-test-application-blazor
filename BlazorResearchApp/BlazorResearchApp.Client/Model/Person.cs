namespace BlazorResearchApp.Client.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string DeviceType { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceOs { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime AccountCreated { get; set; }
        public string AccountStatus { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string LastIpAddress { get; set; }
        public int LoginAttempts { get; set; }
        public bool AccountLocked { get; set; }
        public DateTime PasswordLastChanged { get; set; }

    }
}
