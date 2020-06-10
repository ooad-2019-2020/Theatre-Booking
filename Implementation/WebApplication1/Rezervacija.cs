using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            Sjediste = new HashSet<Sjediste>();
        }

        public int RezervacijaId { get; set; }
        public int PredstavaId { get; set; }

        public virtual Predstava Predstava { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }
    }
}
