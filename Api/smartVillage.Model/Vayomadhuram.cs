using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class Vayomadhuram
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        [StringLength(300)]
        public string PermanentAddress { get; set; }
        [StringLength(300)]
        public string PresentAddress { get; set; }
        [StringLength(100)]
        public string MobileNo { get; set; }
        [StringLength(100)]
        public string AadharNo { get; set; }
        [StringLength(100)]
        public string RationCardNo { get; set; }
        [StringLength(100)]
        public string RationPriority { get; set; }

        public bool IsSelfAttested { get; set; }
        public bool IsDiabetic { get; set; }
        public bool IsGlucoseMeterUser { get; set; }

        [StringLength(200)]
        public string HospitalName { get; set; }
        [StringLength(100)]
        public string DiabeticPeriod { get; set; }

        [StringLength(100)]
        public string DocName { get; set; }
        [StringLength(100)]
        public string IdMark { get; set; }
        [StringLength(100)]
        public string TreatmentDuration { get; set; }
        [StringLength(100)]
        public string Designation { get; set; }
        [StringLength(100)]
        public string RegNo { get; set; }
        [StringLength(100)]
        public string Place { get; set; }

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
