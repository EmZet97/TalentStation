namespace TalentStation.Models.Common
{
    public record UserResponse
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
