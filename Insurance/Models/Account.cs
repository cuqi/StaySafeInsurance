using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }

        // if the account is agent
        public int? AgentId { get; set; }
        [Display(Name = "Агент")]
        public Agent Agent { get; set; }

        // if the account is user 

        public int? UserId { get; set; }
        [Display(Name = "Осигуреник")]
        public User User { get; set; }
    }
}
