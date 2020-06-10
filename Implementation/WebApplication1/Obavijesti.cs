using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Obavijesti
    {
        public Obavijesti()
        {
            InverseObavijest = new HashSet<Obavijesti>();
        }

        public int Id { get; set; }
        public string Tekst { get; set; }
        public int? ObavijestId { get; set; }

        public virtual Obavijesti Obavijest { get; set; }
        public virtual ICollection<Obavijesti> InverseObavijest { get; set; }
    }
}
