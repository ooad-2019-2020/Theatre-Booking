using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Predstava
    {
        public Predstava()
        {
            Rezervacija = new HashSet<Rezervacija>();
            Sjediste = new HashSet<Sjediste>();
        }

        public int PredstavaId { get; set; }
        public DateTime Termin { get; set; }
        public int DogadjajId { get; set; }

        public virtual Dogadjaj Dogadjaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }
    }
}
