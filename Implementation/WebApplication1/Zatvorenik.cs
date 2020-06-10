using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Zatvorenik
    {
        public Zatvorenik()
        {
            Prekrsaj = new HashSet<Prekrsaj>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? SektorId { get; set; }
        public int ZatvorskaKazna { get; set; }
        public string Evaluacija { get; set; }
        public int Jmbg { get; set; }

        public virtual Sektor Sektor { get; set; }
        public virtual ICollection<Prekrsaj> Prekrsaj { get; set; }
    }
}
