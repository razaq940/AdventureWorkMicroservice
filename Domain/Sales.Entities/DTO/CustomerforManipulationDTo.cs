using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public abstract class CustomerforManipulationDTo
    {
        [Required(ErrorMessage = "Customer ID is required")]
        [MaxLength(5, ErrorMessage = "Maximum length for customer id is 5 characters")]
        public int customerId { get; set; }
        public int storeId { get; set; }
        public int territoryId { get; set; }

        
    }
}
