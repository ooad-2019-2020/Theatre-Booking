using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Sjediste
    {
        public int SjedisteId { get; set; }
        public int BrojSjedista { get; set; }
        public bool Slobodno { get; set; }
        public double Cijena { get; set; }
        public int RezervacijaId { get; set; }
        public int? PredstavaId { get; set; }

        public virtual Predstava Predstava { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
