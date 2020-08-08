using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Insurance.Models
{
    public class Account : IdentityUser
    {
        [Display(Name = "Улога")]
        public string Role { get; set; }

        // if the account is agent
        public int? AgentId { get; set; }
        [Display(Name = "Агент")]
        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

        // if the account is user 
        public int? UserId { get; set; }
        [Display(Name = "Осигуреник")]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
