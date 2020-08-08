using Insurance.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.ViewModels
{
    public class GroupPoliciesViewModel
    {
        public IList<CascoPolicy> CascoPolicies { get; set; }
        public IList<HealthPolicy> HealthPolicies { get; set; }
        public IList<TravelPolicy> TravelPolicies { get; set; }

        public IList<Policy> Policies { get; set; }

        public string SearchString { get; set; }

        public string PT { get; set; }
        public SelectList PolicyType { get; set; }
    }
}
