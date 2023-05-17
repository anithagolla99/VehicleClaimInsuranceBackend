using System;
using System.Collections.Generic;

namespace VICMAPI.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Claims = new HashSet<Claims>();
            Vehicles = new HashSet<Vehicles>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContact { get; set; }
        public string LicenceNo { get; set; }
        public string CustomerPassword { get; set; }

        public ICollection<Claims> Claims { get; set; }
        public ICollection<Vehicles> Vehicles { get; set; }
    }
}
