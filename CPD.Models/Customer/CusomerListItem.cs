using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Customer
{
    public class CusomerListItem
    {
        [Key]
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}
