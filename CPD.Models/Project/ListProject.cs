using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Project
{
    public class ListProject
    {
        [Required]
        public string Name { get; set; }

        public string TypeOfProject { get; set; }


        [Key]
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int CustomerID { get; set; }

    }
}
