using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class VillageDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StateId { get; set; }
        public virtual StateDto State { get; set; }
        public long DistrictId { get; set; }
        public virtual DistrictDto District { get; set; }
        public bool IsActive { get; set; }
    }
}