using System;
using System.Collections.Generic;

namespace VICMAPI.Models
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            Policies = new HashSet<Policies>();
        }

        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleNo { get; set; }
        public double VehiclePrice { get; set; }
        public DateTime VehiclePurchasedDate { get; set; }
        public int? CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<Policies> Policies { get; set; }
    }
}
