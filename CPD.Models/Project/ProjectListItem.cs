using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Project
{
    public class ProjectListItem
    {
        [Required]
        public string Name { get; set; }
 
        [Key]
        [Required]
        public Guid ProjectID { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

    }
}
