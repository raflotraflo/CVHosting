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

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public byte[] Content { get; set; }

    }
}