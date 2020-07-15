﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Data
{
    public class Project
    {
        [Key]
        [Required]
        public int ProjectID { get; set; }
        [Required]       
        public string Name { get; set; }

        [Display(Name = "Project Type")]
        public string TypeOfProject { get; set; }


        public string Notes { get; set; }

        [Display(Name = "Project Cost")]
        public decimal ProjectCost { get; set; }


        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int CustomerID { get; set; }

        // public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
