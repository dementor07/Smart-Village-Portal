using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class UnmarriedWomenPensionDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public string PensionCode { get; set; }

        public string Name { get; set; }
        public string CareOf { get; set; }
        public string Gender { get; set; }
        public string WardNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Address { get; set; }
        public string PostOffice { get; set; }
        public string Pincode { get; set; }
        public string MobileNumber { get; set; }
        public string RationCardNumber { get; set; }

        public float Income { get; set; }

        public string WardMemberName { get; set; }
        public string ModeOfPayment { get; set; }

        public bool IsServicePension { get; set; }
        public bool IsIncomeTaxPayable { get; set; }
        public bool IsEmployeeProvidentPensionTaker { get; set; }

        public string LandOwnership { get; set; }
        public string ResidingYears { get; set; }

        public DateTime? IssueDate { get; set; }
        public long? IssueById { get; set; }
        public virtual UserDto IssueBy { get; set; }
        public long? ApproveById { get; set; }
        public virtual UserDto ApproveBy { get; set; }
        public long CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public long VillageId { get; set; }
        public virtual VillageDto Village { get; set; }
        public long DistrictId { get; set; }
        public virtual DistrictDto District { get; set; }
        public long StateId { get; set; }
        public virtual StateDto State { get; set; }
    }
}