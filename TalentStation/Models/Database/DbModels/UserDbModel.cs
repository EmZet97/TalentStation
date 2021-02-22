using System.ComponentModel.DataAnnotations;

namespace TalentStation.Models.Database.DbModels
{
    public class UserDbModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string SecondName { get; set; }

        public virtual PasswordDbModel[] UserPasswords { get; set; }
    }
}
