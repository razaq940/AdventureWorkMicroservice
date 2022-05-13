﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string PersonType { get; set; }
        public string FullName { get; set; }
        public int? StoreId { get; set; }
        public string StoreName { get; set; }
        public string Territory { get; set; }
    }
}
