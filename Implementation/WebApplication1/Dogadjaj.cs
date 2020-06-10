using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Dogadjaj
    {
        public Dogadjaj()
        {
            Predstava = new HashSet<Predstava>();
        }

        public int DogadjajId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual ICollection<Predstava> Predstava { get; set; }
    }
}
