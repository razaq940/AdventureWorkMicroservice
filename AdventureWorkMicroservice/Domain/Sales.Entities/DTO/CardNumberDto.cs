using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class CardNumberDto
    {
        public int BusinessEntityId { get; set; }
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
    }
}
