using System;
using System.Collections.Generic;

namespace VICMAPI.Models
{
    public partial class Policies
    {
        public Policies()
        {
            Claims = new HashSet<Claims>();
        }

        public int PolicyId { get; set; }
        public double InsurenceAmount { get; set; }
        public string PolicyType { get; set; }
        public string VehicleType { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public int? VehicleId { get; set; }
        public int? ComapanyIdentificationNo { get; set; }

        public InsuranceCompanyDetails ComapanyIdentificationNoNavigation { get; set; }
        public Vehicles Vehicle { get; set; }
        public ICollection<Claims> Claims { get; set; }
    }
}
