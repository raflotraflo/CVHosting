﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Repository.Models
{
    public class Availability
    {

        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Display(Name = "Dyspozycyjność")]
        [Required]
        public string Name { get; set; }

    }
}