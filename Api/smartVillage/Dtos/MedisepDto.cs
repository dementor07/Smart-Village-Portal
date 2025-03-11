using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class MedisepDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string MobileNo { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime RetirementDate { get; set; }
        public string PostOffice { get; set; }
        public string PenNo { get; set; }
        public string PPO { get; set; }
        public string Treasury { get; set; }
        public string Agency { get; set; }
        public string PensionSchemesAvailed { get; set; }
        public string AadharNo { get; set; }
        public string IdNo { get; set; }
        public string PANno { get; set; }
        public string BloodGroup { get; set; }

        public bool IsSchemeUser { get; set; }
        public string SchemeNo { get; set; }
        public string PermanentAddress { get; set; }


        public bool IsAllowanceGranted { get; set; }
        public string Allowance { get; set; }
        public bool IsChildScheme { get; set; }

        public string PartnerName { get; set; }
        public string PartnerAadharNo { get; set; }
        public string PartnerIdNo { get; set; }
        public string PartnerBloodGroup { get; set; }

        public string ChildName { get; set; }
        public string ChildAadhar { get; set; }
        public string ChildIDno { get; set; }
        public DateTime ChildDOB { get; set; }
        public string ChildGender { get; set; }
        public string ChildBloodGroup { get; set; }


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