using System;
using System.ComponentModel.DataAnnotations;

namespace TalentStation.Models.Database.DbModels
{
    public class PasswordDbModel
    {
        [Key]
        public int Id { get; set; }

        [MinLength(64)]
        [MaxLength(64)]
        public string Password { get; set; }

        public DateTime TimeStamp { get; set; }

        public virtual UserDbModel Owner { get; set; }
    }
}
