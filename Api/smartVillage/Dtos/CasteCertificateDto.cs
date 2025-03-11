using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using smartVillage.Model;

namespace smartVillage.Dtos
{
    public class CasteCertificateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string PostOffice { get; set; }
        public string Location { get; set; }
        public string Taluk { get; set; }
        public DateTime Date { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Reason { get; set; }
        public bool IsActive { get; set; }


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
        public long ReligionId { get; set; }
        public virtual ReligionDto Religion { get; set; }
        public long CasteId { get; set; }
        public virtual CasteDto Caste { get; set; }
    }
}
