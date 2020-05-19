using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Predstava
    {
        public int PredstavaID { get; set; }
        public DateTime Termin { get; set; }
        public int DogadjajID { get; set; }
        public virtual Dogadjaj Dogadjaj { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }

    }
}
