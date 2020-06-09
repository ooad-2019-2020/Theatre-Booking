using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Rezervacija
    {
        [ScaffoldColumn(false)]
        public int RezervacijaID { get; set; }
        /*public double UkupniTrosak { get; set; }*/
        [Display(Name = "Odaberite datum i vrijeme održavanja željene predstave")]
      
        public int PredstavaID { get; set; }
        
        public virtual Predstava Predstava { get; set; }

    }
}
