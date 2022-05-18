using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class AddToCartDto
    {
        public int ProductId { get; set; }
        public string CustomerId { get; set; }
    }
}
