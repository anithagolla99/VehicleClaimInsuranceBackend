using System;
using System.Collections.Generic;

namespace VICMAPI.Models
{
    public partial class InsuranceCompanyDetails
    {
        public InsuranceCompanyDetails()
        {
            Policies = new HashSet<Policies>();
        }

        public int ComapanyIdentificationNo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyAddress { get; set; }

        public ICollection<Policies> Policies { get; set; }
    }
}
