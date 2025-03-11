using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Web;

namespace smartVillage.Model
{
        public class Department
        {
            public long Id { get; set; } 
                [StringLength(100)]
                public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    
}
