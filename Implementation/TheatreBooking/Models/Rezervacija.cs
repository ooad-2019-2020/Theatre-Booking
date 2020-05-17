using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Rezervacija
    {
        public int RezervacijaID { get; set; }
        public double UkupniTrosak { get; set; }
        public int KorisnikID { get; set; }
        public int PredstavaID { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Predstava Predstava { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }

    }
}
