﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGM.Domain.Entities
{
    public class UserResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
