﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Resources
{

    public class LogResource
    {
        public  LogLevelResource Level { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}
