using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class SnehapoorvamDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }

        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }

        public string School { get; set; }
        public string NatureOfSchool { get; set; }
        public string ClassStudied { get; set; }
        public string SchoolDistrict { get; set; }

        public string JobType { get; set; }
        public string RevenueDistrict { get; set; }

        public string FatherName { get; set; }
        public bool IsFatherAlive { get; set; }
        public string MotherName { get; set; }
        public bool IsMotherAlive { get; set; }

        public string GuardianName { get; set; }
        public string GuardianNameNo { get; set; }
        public string GuardianAddress { get; set; }
        public string RelationshipwithStudent { get; set; }

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