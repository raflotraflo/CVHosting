﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Repository.Models
{
    public class User : IdentityUser
    {
        // Dodajemy pola Imie i Nazwisko:
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }


        #region dodatkowe pole notmapped

        [NotMapped]     // using System.ComponentModel.DataAnnotations.Schema;
        [Display(Name = "Pan/Pani:")]
        public string FullName
        {
            get { return Name + " " + Surname; }
        }

        #endregion


        //public virtual ICollection<Ogloszenie> Ogloszenia { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}