using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class KorisnikUloga
    {
        public enum VIPKartica { Srebrena, Zlatna };
        public enum Uloga { Admin, PremiumKupac, Kupac };

        [ScaffoldColumn(false)]
        public int KorisnikUlogaID { get; set; }
        [Display(Name = "Tip korisnika")]
        [Required]
        public Uloga TipKorisnika { get; set; }
        [Display(Name = "Vrsta VIP kartice")]
        public VIPKartica VrstaKartice { get; set; }

        [Display(Name = "ID kartice")]
        public int BrojKartice { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
