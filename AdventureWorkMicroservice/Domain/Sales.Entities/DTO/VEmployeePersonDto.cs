﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class VEmployeePersonDto
    {
        public int BusinessEntityID { get; set; }
        public string FullName { get; set; }
        public string NationalIDNumber { get; set; }
        public string JobTitle { get; set; }
    }
}
