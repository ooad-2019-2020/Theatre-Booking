using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class Dogadjaj
    {
        [ScaffoldColumn(false)]
        public int DogadjajID { get; set; }
        [Display(Name = "Naziv predstave")]
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }

       public string CreatedByUserID { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual ICollection<Predstava> Predstava { get; set; }
    }
}
