namespace TalentStation.Models.Common
{
    public record UserRequest
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
    }
}
