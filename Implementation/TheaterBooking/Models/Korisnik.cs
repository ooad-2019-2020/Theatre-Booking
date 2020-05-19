using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int KorisnikUlogaID { get; set; }
        public virtual KorisnikUloga KorisnikUloga { get; set; }


    }
}
