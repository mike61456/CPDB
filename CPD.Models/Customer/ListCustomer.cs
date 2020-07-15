using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Customer
{
    public class ListCustomer
    {
        [Key]
        public int CustomerID { get; set; }

        public string Name { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}
