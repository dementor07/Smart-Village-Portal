using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using smartVillage.Model;

namespace smartVillage.Dtos
{
    public class EmployeeId
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public long IssuebyId { get; set; }
        public virtual District District { get; set; }
        public bool IsActive { get; set; }

    }
}