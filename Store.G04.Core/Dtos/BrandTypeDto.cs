﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Dtos
{
    public class BrandTypeDto
    {
        public string Name { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    }
}
