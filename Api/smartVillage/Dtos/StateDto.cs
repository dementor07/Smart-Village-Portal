using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartVillage.Dtos
{
    public class StateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}