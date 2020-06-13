using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class CascoPolicy
    {
        [Key] //autoincrement for cascopolicy id
        public int Id { get; set; }

        [Required]
        [StringLength(17)] // the chassis number of the vehicle
        public string Chassis { get; set; }

        [Required]
        [StringLength(8)] // the registration number of the vehicle
        public string Registration { get; set; }

        public int Power { get; set; } // horsepower of the vehicle

        public int Volume { get; set; } // volume of the vehicle

        public int Premium { get; set; } // total premium for the policy

        public string VehicleColor { get; set; } // the color of the vehicle

        [Display(Name = "Датум на потпишување")]
        [DataType(DataType.Date)] // agreedate for policy
        public DateTime? AgreeDate { get; set; }

        public int? PolicyId { get; set; } // foreign key of policy 

        public Policy Policy { get; set; }

    }
}
