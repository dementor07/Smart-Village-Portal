using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.UI;

namespace smartVillage.Model
{
    public class IncomeCertificate
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Gender { get; set; }
        public int Age { get; set; }
        [StringLength(100)]
        public string FatherName { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(100)]
        public string PostOffice { get; set; }
        [StringLength(100)]
        public string Pincode { get; set; }
        [StringLength(100)]
        public string Taluk { get; set; }
        [StringLength(250)]
        public string Reason { get; set; }
        public float AnnualIncome { get; set; }
        [StringLength(250)]
        public string CompanyName { get; set; }
        [StringLength(250)]
        public string CompanySector { get; set; }

        public DateTime Date { get; set; }
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

