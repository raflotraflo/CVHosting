using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class MessageLog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Type { get; set; }

        public string Excepction { get; set; }

        public string Path { get; set; }
    }
}