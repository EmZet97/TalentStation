using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDbModel User { get; set; }
    }
}
