using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Korisnik : IdentityUser
    {
        [ScaffoldColumn(false)]
        public int KorisnikID { get; set; }
        [Required(ErrorMessage = "Unisite ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unisite prezime")]
        public string Prezime { get; set; }
        [Display(Name = "Korisničko ime")]
        [Required(ErrorMessage = "Unisite korisničko ime")]
        public string Username { get; set; }
        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Unesite lozinku")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Lozinka treba da sadrži najmanje 8 znakova")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Unesite email adresu")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
       
        public string ImePrezime { get { return string.Format("{0} {1}", Ime, Prezime); } }
        public int KorisnikUlogaID { get; set; }
        public virtual KorisnikUloga KorisnikUloga { get; set; }


    }
}
