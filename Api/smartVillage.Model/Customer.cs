using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class Customer
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string MobileNo { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(250)]
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }

        public long StateId { get; set; }
        public virtual State State { get; set; }
        public long DistrictId { get; set; }
        public virtual District District { get; set; }
        public long VillageId { get; set; }
        public virtual Village Village { get; set; }
    }
}
