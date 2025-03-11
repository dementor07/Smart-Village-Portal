using System;

namespace smartVillage.Dtos
{
    public class IncomeCertificateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string PostOffice { get; set; }
        public string Pincode { get; set; }
        public string Taluk { get; set; }
        public string Reason { get; set; }
        public float AnnualIncome { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }

        public DateTime Date { get; set; }
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