using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class User
    {
        [Key] //autoincrement id 
        public int Id { get; set; }

        [Required]
        [StringLength(50)] // user firstname
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)] // user lastname
        public string LastName { get; set; } 

        [Required]
        [StringLength(13)] //user unique number
        public string EMBG { get; set; }

        [Display(Name = "Датум на раѓање")]
        [DataType(DataType.Date)] // birthdate of user
        public DateTime? BirthDate { get; set; }
    }
}
