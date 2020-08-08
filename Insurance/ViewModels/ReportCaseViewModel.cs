using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Insurance.Models;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace Insurance.ViewModels
{
    public class ReportCaseViewModel
    {
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "Датум на незгодата")]
        [DataType(DataType.Date)] // accidentdate for case
        public DateTime? AccidentDate { get; set; }
        public int UserId { get; set; } // foreign key of policy
        public User User { get; set; } // info about the policy

    }
}
