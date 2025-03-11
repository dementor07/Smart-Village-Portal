using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace smartVillage.Dtos
{
    public class FamilyMemberDto 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }

        public long StateId { get; set; }
        public virtual StateDto State { get; set; }
        public long DistrictId { get; set; }
        public virtual DistrictDto District { get; set; }
        public long VillageId { get; set; }
        public virtual VillageDto Village { get; set; }
    }
}
