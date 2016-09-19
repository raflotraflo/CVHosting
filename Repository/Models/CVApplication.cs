using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class CVApplication
    {
        [Display(Name = "Id:")]
        public int Id { get; set; }

        [Display(Name = "Stanowisko pracy:")]
        [MaxLength(72)]
        [Required]
        public string Workplace { get; set; }

        [Display(Name = "Imię i Nazwisko:")]
        [MaxLength(72)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Dodatkowe informacje:")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataDodania { get; set; }

        public int? CVFileId { get; set; }

        public int PlaceId { get; set; }
        public int AvailabilityId { get; set; }

        public virtual Place Place { get; set; }
        public virtual Availability Availability { get; set; }
    }
}