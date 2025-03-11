﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartVillage.Model
{
    public class User
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string PasswordSalt { get; set; }
        [StringLength(256)]
        public string Password { get; set; }
        public bool IsActive { get; set; }

        [StringLength(50)]
        public string Role { get; set; }
        public bool IsBlocked { get; set; }
        public long? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
       
    }
}
