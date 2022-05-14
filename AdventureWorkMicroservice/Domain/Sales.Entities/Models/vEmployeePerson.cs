using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Entities.Models
{
    public partial class vEmployeePerson
    {
        public int BusinessEntityID { get; set; }
        public string FullName { get; set; }
        public string NationalIDNumber { get; set; }
        public string JobTitle { get; set; }
    }
}
