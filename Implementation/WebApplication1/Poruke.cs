using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Poruke
    {
        public Poruke()
        {
            InversePoruka = new HashSet<Poruke>();
        }

        public int Id { get; set; }
        public string Tekst { get; set; }
        public string PrimalacEmail { get; set; }
        public string PosiljalacEmail { get; set; }
        public int? PorukaId { get; set; }

        public virtual Poruke Poruka { get; set; }
        public virtual ICollection<Poruke> InversePoruka { get; set; }
    }
}
