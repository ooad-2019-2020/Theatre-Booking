using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Dogadjaj
    {
        public int DogadjajID { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string Slika { get; set; }
        public virtual ICollection<Predstava> Predstava { get; set; }
    }
}
