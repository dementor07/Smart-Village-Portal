using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class Village
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public long StateId { get; set; }
        public virtual State State { get; set; }
        public long DistrictId { get; set; }
        public virtual District District { get; set; }
        public bool IsActive { get; set; }


    }
}
