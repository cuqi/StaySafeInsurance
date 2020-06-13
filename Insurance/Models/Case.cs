using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class Case
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CaseNumber { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Датум на незгодата")]
        [DataType(DataType.Date)] // accidentdate for case
        public DateTime? AccidentDate { get; set; }

        public int? InsuredId { get; set; } // foreign key of insured
        public User Insured { get; set; } // info about the insured user
    }
}
