using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smartVillage.Model;

namespace smartVillage.Dtos
{
    public class CasteDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StateId { get; set; }
        public virtual State State { get; set; }
        public bool IsActive { get; set; }
    }
}