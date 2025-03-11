using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class FamilyMembershipDetailsDto
    {
        public long Id { get; set; }
        public string RelativeName { get; set; }
        public string Relationship { get; set; }
        public int Age { get; set; }
        public string FamilyMembershipCertificateId { get; set; }
        public long VillageId { get; set; }
    }
}