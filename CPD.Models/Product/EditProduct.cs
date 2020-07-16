using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Product
{
    public class EditProduct
    {
        [Key]
        [Required]
        public int ProductID { get; set; }

        [Required]
        
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public double Quantity { get; set; }
        [Required]
        public int ProjectID { get; set; }



        //    [Required]
        //   public Guid OwnerId { get; set; }
    }
}
