using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    internal class FamilyMembershipDetails
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string RelativeName { get; set; }
        [StringLength(100)]
        public string Relationship { get; set; }
        [StringLength(100)]
        public int Age { get; set; }
        public string FamilyMembershipCertificateId { get; set; }
        [StringLength(100)]
        public virtual Village Village { get; set; }
    }
}
