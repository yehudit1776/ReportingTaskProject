﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class Access
    {
        [Required]
        public int AccessId { get; set; }
        [Required]
        public string AccessName { get; set; }
      
    }
}
