using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Product
{
    public class ProductListItem
    {
        [Key]
        [Required]
        public Guid ItemID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Required]
        public Guid OwnerId { get; set; }

    }
}
