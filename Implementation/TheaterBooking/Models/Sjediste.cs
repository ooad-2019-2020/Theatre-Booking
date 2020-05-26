using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Sjediste
    {
        public int SjedisteID { get; set; }
        public int BrojSjedista { get; set; }
        public Boolean Slobodno { get; set; }
        public double Cijena { get; set; }
        public int RezervacijaID { get; set; }

        public virtual Rezervacija Rezervacija { get; set; }

    }
}
