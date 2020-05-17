using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class KorisnikUloga
    {
        public int KorinikUlogaId { get; set; }
        public string Uloga { get; set; }
        public int Popust { get; set; }
        public int KarticaID { get; set; }
        public string VrstaKartice { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
