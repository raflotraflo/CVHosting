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
        [Required(ErrorMessage = "Uzupełnij stanowisko")]
        public string Workplace { get; set; }

        [Display(Name = "Imię i Nazwisko:")]
        [MaxLength(72)]
        [Required(ErrorMessage = "Podaj Imie i Nazwisko")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Podaj właściwy e-mail")]
        [Required(ErrorMessage = "Podaj e-mail do kontaktu")]
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

        [Display(Name = "Skąd się o nas dowiedziałeś?")]
        public int PlaceId { get; set; }

        [Display(Name = "Twoja dostępność?")]
        public int AvailabilityId { get; set; }

        public virtual Place Place { get; set; }
        public virtual Availability Availability { get; set; }
        //public virtual CVFile CVFile { get; set; }
    }
}