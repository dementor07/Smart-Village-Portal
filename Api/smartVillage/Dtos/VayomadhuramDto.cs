using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class VayomadhuramDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string MobileNo { get; set; }
        public string AadharNo { get; set; }
        public string RationCardNo { get; set; }
        public string RationPriority { get; set; }

        public bool IsSelfAttested { get; set; }
        public bool IsDiabetic { get; set; }
        public bool IsGlucoseMeterUser { get; set; }

        public string HospitalName { get; set; }
        public string DiabeticPeriod { get; set; }

        public string DocName { get; set; }
        public string IdMark { get; set; }
        public string TreatmentDuration { get; set; }
        public string Designation { get; set; }
        public string RegNo { get; set; }
        public string Place { get; set; }

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