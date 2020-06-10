using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Prekrsaj
    {
        public int Id { get; set; }
        public string Zapisnik { get; set; }
        public string KaznenoDjelo { get; set; }
        public DateTime DatumPrekrsaja { get; set; }
        public DateTime DatumPritvora { get; set; }
        public DateTime DatumSudskeOdluke { get; set; }
        public int? ZatvorenikId { get; set; }

        public virtual Zatvorenik Zatvorenik { get; set; }
    }
}
