using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Project
{
    public class CreateProject
    {
        [Required]
        
        public string Name { get; set; }

        [Display(Name = "Project Type")]
        public string TypeOfProject { get; set; }


        public string Notes { get; set; }

        [Display(Name = "Project Cost")]
        public decimal ProjectCost { get; set; }

        [Key]
        [Required]
        public int ProjectID { get; set; }
     
        [Required]
        public int CustomerID { get; set; }
    }
}
