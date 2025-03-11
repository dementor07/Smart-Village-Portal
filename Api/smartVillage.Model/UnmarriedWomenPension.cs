using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class UnmarriedWomenPension
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string PensionCode { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string CareOf { get; set; }
        [StringLength(100)]
        public string Gender { get; set; }
        [StringLength(100)]
        public string WardNumber { get; set; }
        [StringLength(100)]
        public string HouseNumber { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string PostOffice { get; set; }
        [StringLength(100)]
        public string Pincode { get; set; }
        [StringLength(100)]
        public string MobileNumber { get; set; }
        [StringLength(100)]
        public string RationCardNumber { get; set; }

        public float Income { get; set; }

        [StringLength(100)]
        public string WardMemberName { get; set; }
        [StringLength(100)]
        public string ModeOfPayment { get; set; }

        public bool IsServicePension { get; set; }
        public bool IsIncomeTaxPayable { get; set; }
        public bool IsEmployeeProvidentPensionTaker { get; set; }

        [StringLength(100)]
        public string LandOwnership { get; set; }
        [StringLength(100)]
        public string ResidingYears { get; set; }

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
