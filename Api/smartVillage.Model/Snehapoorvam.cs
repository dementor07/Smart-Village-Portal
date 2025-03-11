using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class Snehapoorvam
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string MobileNo { get; set; }
        [StringLength(300)]
        public string Address { get; set; }
        [StringLength(100)]
        public string PinCode { get; set; }

        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }

        [StringLength(200)]
        public string School { get; set; }
        [StringLength(100)]
        public string NatureOfSchool { get; set; }
        [StringLength(100)]
        public string ClassStudied { get; set; }
        [StringLength(100)]
        public string SchoolDistrict { get; set; }

        [StringLength(100)]
        public string JobType { get; set; }
        [StringLength(100)]
        public string RevenueDistrict { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }
        public bool IsFatherAlive { get; set; }
        [StringLength(100)]
        public string MotherName { get; set; }
        public bool IsMotherAlive { get; set; }

        [StringLength(100)]
        public string GuardianName { get; set; }
        [StringLength(100)]
        public string GuardianNameNo { get; set; }
        [StringLength(300)]
        public string GuardianAddress { get; set; }
        [StringLength(100)]
        public string RelationshipwithStudent { get; set; }

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
