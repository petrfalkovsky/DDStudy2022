﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Avatar : Attach
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
