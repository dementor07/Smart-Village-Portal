using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class Medisep
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string MobileNo { get; set; }
        public int Age { get; set; }
        [StringLength(100)]
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime RetirementDate { get; set; }
        [StringLength(100)]
        public string PostOffice { get; set; }
        [StringLength(100)]
        public string PenNo { get; set; }
        [StringLength(100)]
        public string PPO { get; set; }
        [StringLength(100)]
        public string Treasury { get; set; }
        [StringLength(200)]
        public string Agency { get; set; }
        [StringLength(200)]
        public string PensionSchemesAvailed { get; set; }
        [StringLength(100)]
        public string AadharNo { get; set; }
        [StringLength(100)]
        public string IdNo { get; set; }
        [StringLength(100)]
        public string PANno { get; set; }
        [StringLength(100)]
        public string BloodGroup { get; set; }

        public bool IsSchemeUser { get; set; }
        [StringLength(100)]
        public string SchemeNo { get; set; }
        [StringLength(300)]
        public string PermanentAddress { get; set; }

    
        public bool IsAllowanceGranted { get; set; }
        [StringLength(100)]
        public string Allowance { get; set; }
        public bool IsChildScheme { get; set; }

        [StringLength(100)]
        public string PartnerName { get; set; }
        [StringLength(100)]
        public string PartnerAadharNo { get; set; }
        [StringLength(100)]
        public string PartnerIdNo { get; set; }
        [StringLength(100)]
        public string PartnerBloodGroup { get; set; }

        [StringLength(200)]
        public string ChildName { get; set; }
        [StringLength(100)]
        public string ChildAadhar { get; set; }
        [StringLength(100)]
        public string ChildIDno { get; set; }
        public DateTime ChildDOB { get; set; }
        [StringLength(100)]
        public string ChildGender { get; set; }
        [StringLength(100)]
        public string ChildBloodGroup { get; set; }


        public DateTime? IssueDate { get; set; }
        public long? IssueById { get; set; }
        public virtual User IssueBy { get; set; }
        public long? ApproveById { get; set; }
        public virtual User ApproveBy { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public long VillageId { get; set; }
        public virtual Village Village { get; set; }
        public long DistrictId { get; set; }
        public virtual District District { get; set; }
        public long StateId { get; set; }
        public virtual State State { get; set; }

    }
}
