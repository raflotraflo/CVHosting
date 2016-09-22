using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Repository.Models.Views
{
    public class CreateCVApplicationViewModel
    {
        [Required(ErrorMessage = "Podaj Imie i Nazwisko")]
        public CVApplication cvApplication { get; set; }

        [Required(ErrorMessage = "Proszę wybrać plik!")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        [Attachment]
        public HttpPostedFileBase File { get; set; }

        [MustBeTrue(ErrorMessage = "Musisz wyrazić zgodę!")]
        public bool Consent { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AttachmentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
          ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;

            // The file is required.
            if (file == null)
            {
                return new ValidationResult("Proszę wybrać plik!");
            }

            // The meximum allowed file size is 10MB.
            if (file.ContentLength > 5 * 1024 * 1024)
            {
                return new ValidationResult("Za duży plik! < 5MB");
            }

            var allowedExtensions = new List<string>() { ".pdf", ".txt", ".rtf", ".doc", ".docx", ".odt", ".xml" };

            string ext = Path.GetExtension(file.FileName).ToLower();
            if (String.IsNullOrEmpty(ext) || !allowedExtensions.Any(x => ext.Contains(x)))
            {
                string allowed = "";
                allowedExtensions.ForEach(x => allowed += x + " ");
                return new ValidationResult("Dozwolone pliki: " + allowed);
            }

            // Everything OK.
            return ValidationResult.Success;
        }
    }

    public sealed class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
}