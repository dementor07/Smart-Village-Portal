using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace smartVillage.Model
{
    public class Designation
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }        
        public bool IsActive { get; set; }
    }
}
