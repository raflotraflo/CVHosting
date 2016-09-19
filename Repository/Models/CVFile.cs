using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Repository.Models
{
    public class CVFile
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Display(Name = "cv plik")]
        [Required]
        public byte[] Content { get; set; }
    }
}