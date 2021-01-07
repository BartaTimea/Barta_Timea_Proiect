using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barta_Timea_Proiect.Store
{
    public class Assortment
    {
        public int ID { get; set; }
        public string AssortmentName { get; set; }
        public ICollection<WineAssortment> WineAssortments { get; set; }
    }
}
