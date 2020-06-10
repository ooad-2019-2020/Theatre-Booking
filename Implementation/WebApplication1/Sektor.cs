using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Sektor
    {
        public Sektor()
        {
            Zatvorenik = new HashSet<Zatvorenik>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? NadlezniCuvarId { get; set; }

        public virtual Cuvar NadlezniCuvar { get; set; }
        public virtual ICollection<Zatvorenik> Zatvorenik { get; set; }
    }
}
