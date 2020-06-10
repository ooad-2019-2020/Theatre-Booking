using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Cuvar
    {
        public Cuvar()
        {
            Sektor = new HashSet<Sektor>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DatumPrijave { get; set; }

        public virtual ICollection<Sektor> Sektor { get; set; }
    }
}
