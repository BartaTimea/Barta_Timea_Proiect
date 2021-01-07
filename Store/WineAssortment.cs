using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barta_Timea_Proiect.Store
{
    public class WineAssortment
    {
        public int ID { get; set; }
        public int WineID { get; set; }
        public Wine Wine { get; set; }
        public int AssortmentID { get; set; }
        public Assortment Assortment { get; set; }
    }
}
