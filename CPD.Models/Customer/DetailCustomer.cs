﻿using CPD.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Models.Customer
{
    public class DetailCustomer
    {
        [Key]
        public int CustomerID { get; set; }

        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public List<ListProject> Projects { get; set; }



    }
}
