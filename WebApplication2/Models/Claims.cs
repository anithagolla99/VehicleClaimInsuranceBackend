using System;
using System.Collections.Generic;

namespace VICMAPI.Models
{
    public partial class Claims
    {
        public int ClaimId { get; set; }
        public string LicenceNo { get; set; }
        public string SupportedDocuments { get; set; }
        public string ClaimReason { get; set; }
        public string VehicleCondition { get; set; }
        public double ClaimAmount { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string IfscCode { get; set; }
        public string ClaimStatus { get; set; }
        public int? CustomerId { get; set; }
        public int? PolicyId { get; set; }

        public Customers Customer { get; set; }
        public Policies Policy { get; set; }
    }
}
